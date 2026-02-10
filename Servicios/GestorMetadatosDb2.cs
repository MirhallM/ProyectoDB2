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
