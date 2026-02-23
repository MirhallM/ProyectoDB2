using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ProyectoDB2.Modelos;

namespace ProyectoDB2
{
    public class GestorMetadatosDb2
    {
        private readonly GestorConexionDb2 gestorConexion;

        public GestorMetadatosDb2(GestorConexionDb2 gestor)
        {
            gestorConexion = gestor;
        }

        public void ConstruirArbol(TreeView treeView, Action<string>? escribirMensaje)
        {
            treeView.BeginUpdate();
            try
            {
                treeView.Nodes.Clear();

                TreeNode nodoConexiones = CrearNodo(
                    "Conexiones",
                    new InfoNodoBD { Tipo = TipoObjetoBD.Carpeta, Nombre = "Conexiones" }
                );

                TreeNode nodoConexion = CrearNodo(
                    "DB2_Actual",
                    new InfoNodoBD { Tipo = TipoObjetoBD.Conexion, Nombre = "DB2_Actual" }
                );

                TreeNode nodoEsquemas = CrearNodo(
                    "Esquemas",
                    new InfoNodoBD { Tipo = TipoObjetoBD.Carpeta, Nombre = "Esquemas" }
                );

                DataTable dtEsquemas = gestorConexion.EjecutarConsulta(@"
                    SELECT DISTINCT ESQUEMA
                    FROM (
                        SELECT TABSCHEMA AS ESQUEMA FROM SYSCAT.TABLES WHERE TYPE = 'T'
                        UNION
                        SELECT VIEWSCHEMA FROM SYSCAT.VIEWS
                        UNION
                        SELECT PROCSCHEMA FROM SYSCAT.PROCEDURES
                        UNION
                        SELECT FUNCSCHEMA FROM SYSCAT.FUNCTIONS
                        UNION
                        SELECT TRIGSCHEMA FROM SYSCAT.TRIGGERS
                        UNION
                        SELECT INDSCHEMA FROM SYSCAT.INDEXES
                        UNION
                        SELECT SEQSCHEMA FROM SYSCAT.SEQUENCES
                        UNION
                        SELECT PKGSCHEMA FROM SYSCAT.PACKAGES
                    ) X
                    WHERE ESQUEMA NOT LIKE 'SYS%'
                      AND ESQUEMA NOT IN ('NULLID', 'SQLJ')
                    ORDER BY ESQUEMA
                ");

                foreach (DataRow row in dtEsquemas.Rows)
                {
                    string esquema = (row["ESQUEMA"]?.ToString() ?? "").Trim();
                    if (string.IsNullOrWhiteSpace(esquema)) continue;

                    TreeNode nodoEsquema = CrearNodo(
                        esquema,
                        new InfoNodoBD { Tipo = TipoObjetoBD.Esquema, Nombre = esquema, Esquema = esquema }
                    );

                    TreeNode nodoTablas = CrearCarpeta("Tablas", esquema);
                    TreeNode nodoVistas = CrearCarpeta("Vistas", esquema);
                    TreeNode nodoProcedimientos = CrearCarpeta("Procedimientos", esquema);
                    TreeNode nodoFunciones = CrearCarpeta("Funciones", esquema);
                    TreeNode nodoTriggers = CrearCarpeta("Triggers", esquema);
                    TreeNode nodoIndices = CrearCarpeta("Índices", esquema);
                    TreeNode nodoSecuencias = CrearCarpeta("Secuencias", esquema);
                    TreeNode nodoPaquetes = CrearCarpeta("Paquetes", esquema);

                    LlenarObjetosPorEsquema(nodoTablas, esquema,
                        "SELECT TABNAME AS NOMBRE FROM SYSCAT.TABLES WHERE TABSCHEMA = '{0}' AND TYPE = 'T' ORDER BY TABNAME",
                        "NOMBRE", TipoObjetoBD.Tabla, escribirMensaje);

                    LlenarObjetosPorEsquema(nodoVistas, esquema,
                        "SELECT VIEWNAME AS NOMBRE FROM SYSCAT.VIEWS WHERE VIEWSCHEMA = '{0}' ORDER BY VIEWNAME",
                        "NOMBRE", TipoObjetoBD.Vista, escribirMensaje);

                    LlenarObjetosPorEsquema(nodoProcedimientos, esquema,
                        "SELECT PROCNAME AS NOMBRE FROM SYSCAT.PROCEDURES WHERE PROCSCHEMA = '{0}' ORDER BY PROCNAME",
                        "NOMBRE", TipoObjetoBD.Procedimiento, escribirMensaje);

                    LlenarObjetosPorEsquema(nodoFunciones, esquema,
                        "SELECT FUNCNAME AS NOMBRE FROM SYSCAT.FUNCTIONS WHERE FUNCSCHEMA = '{0}' ORDER BY FUNCNAME",
                        "NOMBRE", TipoObjetoBD.Funcion, escribirMensaje);

                    LlenarObjetosPorEsquema(nodoTriggers, esquema,
                        "SELECT TRIGNAME AS NOMBRE FROM SYSCAT.TRIGGERS WHERE TRIGSCHEMA = '{0}' ORDER BY TRIGNAME",
                        "NOMBRE", TipoObjetoBD.Trigger, escribirMensaje);

                    LlenarObjetosPorEsquema(nodoIndices, esquema,
                        "SELECT INDNAME AS NOMBRE FROM SYSCAT.INDEXES WHERE INDSCHEMA = '{0}' ORDER BY INDNAME",
                        "NOMBRE", TipoObjetoBD.Indice, escribirMensaje);

                    LlenarObjetosPorEsquema(nodoSecuencias, esquema,
                        "SELECT SEQNAME AS NOMBRE FROM SYSCAT.SEQUENCES WHERE SEQSCHEMA = '{0}' ORDER BY SEQNAME",
                        "NOMBRE", TipoObjetoBD.Secuencia, escribirMensaje);

                    LlenarObjetosPorEsquema(nodoPaquetes, esquema,
                        "SELECT PKGNAME AS NOMBRE FROM SYSCAT.PACKAGES WHERE PKGSCHEMA = '{0}' ORDER BY PKGNAME",
                        "NOMBRE", TipoObjetoBD.Paquete, escribirMensaje);

                    nodoEsquema.Nodes.Add(nodoTablas);
                    nodoEsquema.Nodes.Add(nodoVistas);
                    nodoEsquema.Nodes.Add(nodoProcedimientos);
                    nodoEsquema.Nodes.Add(nodoFunciones);
                    nodoEsquema.Nodes.Add(nodoTriggers);
                    nodoEsquema.Nodes.Add(nodoIndices);
                    nodoEsquema.Nodes.Add(nodoSecuencias);
                    nodoEsquema.Nodes.Add(nodoPaquetes);

                    nodoEsquemas.Nodes.Add(nodoEsquema);
                }

                // Objetos globales
                TreeNode nodoGlobales = CrearNodo(
                    "Objetos globales",
                    new InfoNodoBD { Tipo = TipoObjetoBD.Carpeta, Nombre = "Objetos globales" }
                );

                TreeNode nodoTablespaces = CrearNodo(
                    "Tablespaces",
                    new InfoNodoBD { Tipo = TipoObjetoBD.Carpeta, Nombre = "Tablespaces" }
                );

                LlenarObjetosGlobales(nodoTablespaces,
                    "SELECT TBSPACE AS NOMBRE FROM SYSCAT.TABLESPACES ORDER BY TBSPACE",
                    "NOMBRE", TipoObjetoBD.Tablespace, escribirMensaje);

                TreeNode nodoUsuarios = CrearNodo(
                    "Usuarios",
                    new InfoNodoBD { Tipo = TipoObjetoBD.Carpeta, Nombre = "Usuarios" }
                );

                LlenarObjetosGlobales(nodoUsuarios,
                    "SELECT DISTINCT GRANTEE AS NOMBRE FROM SYSCAT.DBAUTH ORDER BY GRANTEE",
                    "NOMBRE", TipoObjetoBD.Usuario, escribirMensaje);

                nodoGlobales.Nodes.Add(nodoTablespaces);
                nodoGlobales.Nodes.Add(nodoUsuarios);

                nodoConexion.Nodes.Add(nodoEsquemas);
                nodoConexion.Nodes.Add(nodoGlobales);
                nodoConexiones.Nodes.Add(nodoConexion);
                treeView.Nodes.Add(nodoConexiones);

                nodoConexiones.Expand();
                nodoConexion.Expand();
                nodoEsquemas.Expand();
            }
            finally
            {
                treeView.EndUpdate();
            }
        }

        private TreeNode CrearCarpeta(string nombreCarpeta, string esquema)
        {
            return CrearNodo(
                nombreCarpeta,
                new InfoNodoBD { Tipo = TipoObjetoBD.Carpeta, Nombre = nombreCarpeta, Esquema = esquema }
            );
        }

        private string EscaparLiteral(string valor)
        {
            return (valor ?? "").Replace("'", "''");
        }

        private void LlenarObjetosPorEsquema(
            TreeNode carpeta,
            string esquema,
            string plantillaSql,
            string colNombre,
            TipoObjetoBD tipo,
            Action<string>? escribirMensaje)
        {
            try
            {
                string sql = string.Format(plantillaSql, EscaparLiteral(esquema));
                DataTable dt = gestorConexion.EjecutarConsulta(sql);

                foreach (DataRow r in dt.Rows)
                {
                    string nombre = (r[colNombre]?.ToString() ?? "").Trim();
                    if (string.IsNullOrWhiteSpace(nombre)) continue;

                    carpeta.Nodes.Add(CrearNodo(
                        nombre,
                        new InfoNodoBD { Tipo = tipo, Nombre = nombre, Esquema = esquema }
                    ));
                }
            }
            catch (Exception ex)
            {
                escribirMensaje?.Invoke($"No se pudo cargar '{carpeta.Text}' para el esquema '{esquema}': {ex.Message}");
            }
        }

        private void LlenarObjetosGlobales(
            TreeNode carpeta,
            string sql,
            string colNombre,
            TipoObjetoBD tipo,
            Action<string>? escribirMensaje)
        {
            try
            {
                DataTable dt = gestorConexion.EjecutarConsulta(sql);

                foreach (DataRow r in dt.Rows)
                {
                    string nombre = (r[colNombre]?.ToString() ?? "").Trim();
                    if (string.IsNullOrWhiteSpace(nombre)) continue;

                    carpeta.Nodes.Add(CrearNodo(
                        nombre,
                        new InfoNodoBD { Tipo = tipo, Nombre = nombre }
                    ));
                }
            }
            catch (Exception ex)
            {
                escribirMensaje?.Invoke($"No se pudo cargar '{carpeta.Text}': {ex.Message}");
            }
        }

        private TreeNode CrearNodo(string texto, InfoNodoBD info)
        {
            TreeNode nodo = new TreeNode(texto);
            nodo.Tag = info;
            return nodo;
        }

        public string ObtenerDDLVista(string esquema, string nombreVista)
        {
            esquema = (esquema ?? "").Trim();
            nombreVista = (nombreVista ?? "").Trim();

            string esq = esquema.Replace("'", "''");
            string nom = nombreVista.Replace("'", "''");

            DataTable dt = gestorConexion.EjecutarConsulta($@"
                SELECT TEXT
                FROM SYSCAT.VIEWS
                WHERE VIEWSCHEMA = '{esq}'
                  AND VIEWNAME = '{nom}'
            ");

            if (dt.Rows.Count == 0)
                return $"-- No se encontró la vista {esquema}.{nombreVista}";

            string texto = (dt.Rows[0]["TEXT"]?.ToString() ?? "").Trim();

            if (string.IsNullOrWhiteSpace(texto))
                return $"-- La vista {esquema}.{nombreVista} no tiene definición disponible.";

            // Por si DB2 guarda el CREATE VIEW completo, a veces lo hace aun no estoy seguro cuando exactamente, pero por las dudas lo manejo
            if (texto.StartsWith("create view", StringComparison.OrdinalIgnoreCase))
            {
                if (!texto.TrimEnd().EndsWith(";"))
                    texto += ";";
                return texto;
            }

            string ddl = $"CREATE VIEW {esquema}.{nombreVista} AS\n{texto}";
            if (!ddl.TrimEnd().EndsWith(";"))
                ddl += ";";
            return ddl;
        }

        public string ObtenerDDLIndice(string esquema, string nombreIndice)
        {
            if(string.IsNullOrWhiteSpace(esquema) || string.IsNullOrWhiteSpace(nombreIndice))
                return "-- Esquema o tabla inválidos.";

            string esquemaSql = esquema.Trim().Replace("'", "''");
            string tablaSql = nombreIndice.Trim().Replace("'", "''");

            string sql = $@"
                SELECT INDNAME, INDNAME, TABSCHEMA, TABNAME, UNIQUERULE
                FROM SYSCAT.INDEXES
                WHERE INDSCHEMA = '{esquemaSql}'
                  AND INDNAME   = '{nombreIndice}'
                ORDER BY INDNAME";

            DataTable dtInfo = gestorConexion.EjecutarConsulta(sql);

            if (dtInfo.Rows.Count == 0)
                return $"-- No se encontró el índice {esquema}.{nombreIndice}";

            DataRow info = dtInfo.Rows[0];

            string tabSchema = (info["TABSCHEMA"]?.ToString() ?? "").Trim();
            string tabName = (info["TABNAME"]?.ToString() ?? "").Trim();    
            string uniqueRule = (info["UNIQUERULE"]?.ToString() ?? "").Trim().ToUpperInvariant();

            bool esUnico = uniqueRule == "U";

            if(string.IsNullOrWhiteSpace(tabSchema) || string.IsNullOrWhiteSpace(tabName))
                return $"-- No se pudo determinar la tabla del índice {esquema}.{nombreIndice}";

            string sqlCols = $@"
                SELECT COLNAME, COLORDER
                FROM SYSCAT.INDEXCOLUSE
                WHERE INDSCHEMA = '{esquemaSql}'
                  AND INDNAME   = '{nombreIndice}'
                ORDER BY COLSEQ";

            DataTable dtColumnas = gestorConexion.EjecutarConsulta(sqlCols);

            if (dtColumnas.Rows.Count == 0)
                return $"-- No se encontraron columnas para el índice {esquema}.{nombreIndice}";

            List<string> columnas = new List<string>();

            foreach (DataRow fila in dtColumnas.Rows)
            {
                string col = (fila["COLNAME"]?.ToString() ?? "").Trim();
                string orden = (fila["COLORDER"]?.ToString() ?? "").Trim().ToUpperInvariant();

                if (string.IsNullOrWhiteSpace(col))
                {
                    columnas.Add("Columna no disponible");
                    continue;
                }

                if (orden == "D")
                    columnas.Add($"{col} DESC");
                else
                    columnas.Add(col);
            }

            string listaColumnas = string.Join(", ", columnas);

            string textoUnico = esUnico ? "UNIQUE " : "";
            string ddl = $"CREATE {textoUnico}INDEX {esquema}.{nombreIndice} ON {tabSchema}.{tabName} ({listaColumnas});";

            return ddl;
        }

        public string ObtenerDDLTabla(string esquema, string nombreTabla)
        {
            if (string.IsNullOrWhiteSpace(esquema) || string.IsNullOrWhiteSpace(nombreTabla))
                return "-- Esquema o tabla inválidos.";

            string esquemaSql = esquema.Trim().Replace("'", "''");
            string tablaSql = nombreTabla.Trim().Replace("'", "''");

            string sqlCols = $@"
                SELECT COLNAME, TYPENAME, LENGTH, SCALE, NULLS, DEFAULT, IDENTITY
                FROM SYSCAT.COLUMNS
                WHERE TABSCHEMA = '{esquemaSql}'
                  AND TABNAME   = '{tablaSql}'
                ORDER BY COLNO";

            DataTable dtColumnas = gestorConexion.EjecutarConsulta(sqlCols);

            if (dtColumnas.Rows.Count == 0)
                return $"-- No se encontró la tabla {esquema}.{nombreTabla}";


            List<string> definiciones = new List<string>();

            foreach (DataRow fila in dtColumnas.Rows)
            {
                string nombreCol = (fila["COLNAME"]?.ToString() ?? "").Trim();
                string tipoBase = (fila["TYPENAME"]?.ToString() ?? "").Trim().ToUpperInvariant();
                string valDefault = (fila["DEFAULT"]?.ToString() ?? "").Trim();
                string identity = (fila["IDENTITY"]?.ToString() ?? "N").Trim().ToUpperInvariant();
                string nulls = (fila["NULLS"]?.ToString() ?? "Y").Trim().ToUpperInvariant();

                int longitud = 0;
                int escala = 0;

                if (fila["LENGTH"] != DBNull.Value) longitud = Convert.ToInt32(fila["LENGTH"]);
                if (fila["SCALE"] != DBNull.Value) escala = Convert.ToInt32(fila["SCALE"]);

                string tipoFinal = FormatearTipoDB2(tipoBase, longitud, escala);

                // Línea base
                string linea = $"{nombreCol} {tipoFinal}";

                // IDENTITY
                if (identity == "Y")
                    linea += " GENERATED ALWAYS AS IDENTITY";

                // DEFAULT
                if (!string.IsNullOrWhiteSpace(valDefault))
                    linea += $" DEFAULT {valDefault}";

                // NULL / NOT NULL
                if (nulls == "N")
                    linea += " NOT NULL";

                definiciones.Add(linea);
            }

            string pk = ObtenerPrimaryKey(esquemaSql, tablaSql);
            if (!string.IsNullOrWhiteSpace(pk))
                definiciones.Add(pk);

            string cuerpoTabla = string.Join(",\n    ", definiciones);

            string ddlFinal = $"CREATE TABLE {esquema}.{nombreTabla} (\n    {cuerpoTabla}\n);";

            return ddlFinal;
        }

        public string ObtenerDDLSecuencia(string esquema, string nombreSecuencia)
        {
            if (gestorConexion == null) return "No hay conexión activa.";

            esquema = (esquema ?? "").Trim();
            nombreSecuencia = (nombreSecuencia ?? "").Trim();

            if (string.IsNullOrWhiteSpace(esquema) || string.IsNullOrWhiteSpace(nombreSecuencia))
                return "-- Esquema o secuencia inválidos.";

            string esq = esquema.Replace("'", "''");
            string seq = nombreSecuencia.Replace("'", "''");

            DataTable dt = gestorConexion.EjecutarConsulta($@"
                SELECT SEQTYPE, INCREMENT, START, MINVALUE, MAXVALUE, CACHE, CYCLE, ORDER, PRECISION
                FROM SYSCAT.SEQUENCES
                WHERE SEQSCHEMA = '{esq}'
                  AND SEQNAME   = '{seq}'
            ");

            if (dt.Rows.Count == 0)
                return $"-- No se encontró la secuencia {esquema}.{nombreSecuencia}";

            DataRow r = dt.Rows[0];

            string seqType = (r["SEQTYPE"]?.ToString() ?? "").Trim().ToUpperInvariant();

            
            if (seqType == "A")
            {
                return $"-- La secuencia {esquema}.{nombreSecuencia} es un alias. DB2 no expone un DDL completo para alias desde el catálogo.";
            }

            // Valores 
            string incremento = (r["INCREMENT"]?.ToString() ?? "").Trim();
            string inicio = (r["START"]?.ToString() ?? "").Trim();
            string minValue = (r["MINVALUE"]?.ToString() ?? "").Trim();
            string maxValue = (r["MAXVALUE"]?.ToString() ?? "").Trim();

            int cache = 0;
            int.TryParse((r["CACHE"]?.ToString() ?? "0").Trim(), out cache);

            string cycle = (r["CYCLE"]?.ToString() ?? "").Trim().ToUpperInvariant(); // Y/N
            string order = (r["ORDER"]?.ToString() ?? "").Trim().ToUpperInvariant(); // Y/N

            int precision = 0;
            int.TryParse((r["PRECISION"]?.ToString() ?? "0").Trim(), out precision);

            string tipo = ObtenerTipoSecuenciaPorPrecision(precision);

            StringBuilder ddl = new StringBuilder();

            ddl.Append($"CREATE SEQUENCE {esquema}.{nombreSecuencia}");

            if (!string.IsNullOrWhiteSpace(tipo))
                ddl.Append($" AS {tipo}");

            if (!string.IsNullOrWhiteSpace(inicio))
                ddl.Append($"\n  START WITH {inicio}");

            if (!string.IsNullOrWhiteSpace(incremento))
                ddl.Append($"\n  INCREMENT BY {incremento}");

            // MIN/MAX
            if (!string.IsNullOrWhiteSpace(minValue))
                ddl.Append($"\n  MINVALUE {minValue}");
            else
                ddl.Append("\n  NO MINVALUE");

            if (!string.IsNullOrWhiteSpace(maxValue))
                ddl.Append($"\n  MAXVALUE {maxValue}");
            else
                ddl.Append("\n  NO MAXVALUE");

            // CYCLE
            if (cycle == "Y") ddl.Append("\n  CYCLE");
            else ddl.Append("\n  NO CYCLE");

            // CACHE: 0 normalmente indica no cache
            if (cache <= 0) ddl.Append("\n  NO CACHE");
            else ddl.Append($"\n  CACHE {cache}");

            // ORDER
            if (order == "Y") ddl.Append("\n  ORDER");
            else ddl.Append("\n  NO ORDER");

            ddl.Append(";");

            return ddl.ToString();
        }

        private string ObtenerTipoSecuenciaPorPrecision(int precision)
        {
            // Mapeo típico en DB2 LUW: 5=SMALLINT, 10=INTEGER, 19=BIGINT. :contentReference[oaicite:1]{index=1}
            if (precision == 5) return "SMALLINT";
            if (precision == 10) return "INTEGER";
            if (precision == 19) return "BIGINT";

            if (precision > 0) return $"DECIMAL({precision},0)";
            
            return "";
        }

        public string ObtenerDDLTrigger(string esquema, string nombreTrigger)
        {
            if (gestorConexion == null) return "No hay conexión activa.";

            esquema = (esquema ?? "").Trim();
            nombreTrigger = (nombreTrigger ?? "").Trim();

            if (string.IsNullOrWhiteSpace(esquema) || string.IsNullOrWhiteSpace(nombreTrigger))
                return "-- Esquema o trigger inválido.";

            string esq = esquema.Replace("'", "''");
            string trg = nombreTrigger.Replace("'", "''");

            // Intentamos traer suficiente metadata por si el TEXT no viene completo
            DataTable dt = gestorConexion.EjecutarConsulta($@"
                SELECT TRIGSCHEMA, TRIGNAME, TABSCHEMA, TABNAME,
                       TRIGTIME, TRIGEVENT, GRANULARITY, TEXT
                FROM SYSCAT.TRIGGERS
                WHERE TRIGSCHEMA = '{esq}'
                  AND TRIGNAME   = '{trg}'
            ");

            if (dt.Rows.Count == 0)
                return $"-- No se encontró el trigger {esquema}.{nombreTrigger}";

            DataRow r = dt.Rows[0];

            string tabSchema = (r["TABSCHEMA"]?.ToString() ?? "").Trim();
            string tabName = (r["TABNAME"]?.ToString() ?? "").Trim();

            string trigTime = (r["TRIGTIME"]?.ToString() ?? "").Trim().ToUpperInvariant();     // B / A / I
            string trigEvent = (r["TRIGEVENT"]?.ToString() ?? "").Trim().ToUpperInvariant();  // I / U / D
            string gran = (r["GRANULARITY"]?.ToString() ?? "").Trim().ToUpperInvariant();     // R / S

            string texto = (r["TEXT"]?.ToString() ?? "").Trim();

            if (string.IsNullOrWhiteSpace(texto))
                return $"-- El trigger {esquema}.{nombreTrigger} no tiene texto disponible en el catálogo.";

            // Caso 1: DB2 ya guarda el CREATE TRIGGER completo en TEXT
            if (texto.StartsWith("create trigger", StringComparison.OrdinalIgnoreCase))
            {
                if (!texto.TrimEnd().EndsWith(";"))
                    texto += ";";
                return texto;
            }

            // Caso 2: TEXT viene parcial, intentamos reconstruir una cabecera simple
            string tiempoSql = trigTime switch
            {
                "B" => "BEFORE",
                "A" => "AFTER",
                "I" => "INSTEAD OF",
                _ => "AFTER"
            };

            string eventoSql = trigEvent switch
            {
                "I" => "INSERT",
                "U" => "UPDATE",
                "D" => "DELETE",
                _ => "INSERT"
            };

            string granSql = gran switch
            {
                "R" => "FOR EACH ROW",
                "S" => "FOR EACH STATEMENT",
                _ => "FOR EACH ROW"
            };

            // Si no se pudo determinar tabla, al menos devolvemos el texto con aviso
            if (string.IsNullOrWhiteSpace(tabSchema) || string.IsNullOrWhiteSpace(tabName))
            {
                StringBuilder ddlParcial = new StringBuilder();
                ddlParcial.AppendLine($"-- DDL parcial: no se pudo determinar la tabla objetivo del trigger {esquema}.{nombreTrigger}");
                ddlParcial.AppendLine(texto);
                if (!ddlParcial.ToString().TrimEnd().EndsWith(";"))
                    ddlParcial.AppendLine(";");
                return ddlParcial.ToString();
            }

            StringBuilder ddl = new StringBuilder();
            ddl.AppendLine($"CREATE TRIGGER {esquema}.{nombreTrigger}");
            ddl.AppendLine($"{tiempoSql} {eventoSql} ON {tabSchema}.{tabName}");
            ddl.AppendLine($"{granSql}");
            ddl.AppendLine(texto);

            if (!ddl.ToString().TrimEnd().EndsWith(";"))
                ddl.AppendLine(";");

            return ddl.ToString();
        }

        private string FormatearTipoDB2(string tipo, int longitud, int escala)
        {
            if (string.IsNullOrWhiteSpace(tipo)) return "";
            tipo = tipo.Trim().ToUpperInvariant();

            // Tipos con longitud
            if (tipo is "CHAR" or "VARCHAR" or "GRAPHIC" or "VARGRAPHIC")
                return $"{tipo}({longitud})";

            // Decimal: longitud = precision, escala = scale
            if (tipo is "DECIMAL" or "NUMERIC")
                return $"{tipo}({longitud},{escala})";

            // Timestamp con precisión opcional
            if (tipo == "TIMESTAMP" && escala > 0)
                return $"{tipo}({escala})";

            return tipo;
        }

        private string ObtenerPrimaryKey(string esquema, string tabla)
        {
            string sql = $@"
                SELECT KCU.COLNAME
                FROM SYSCAT.TABCONST TC
                JOIN SYSCAT.KEYCOLUSE KCU
                  ON TC.CONSTNAME = KCU.CONSTNAME
                 AND TC.TABSCHEMA = KCU.TABSCHEMA
                 AND TC.TABNAME   = KCU.TABNAME
                WHERE TC.TABSCHEMA = '{esquema}'
                  AND TC.TABNAME   = '{tabla}'
                  AND TC.TYPE = 'P'
                ORDER BY KCU.COLSEQ";

            DataTable tablaResultados = gestorConexion.EjecutarConsulta(sql);
            if (tablaResultados.Rows.Count == 0) return "";

            List<string> columnasPk = new List<string>();

            foreach (DataRow fila in tablaResultados.Rows)
            {
                string nombreColumna = (fila["COLNAME"]?.ToString() ?? "").Trim();
                if (!string.IsNullOrWhiteSpace(nombreColumna))
                    columnasPk.Add(nombreColumna);
            }

            if (columnasPk.Count == 0) return "";

            return $"PRIMARY KEY ({string.Join(", ", columnasPk)})";
        }

    }
}
