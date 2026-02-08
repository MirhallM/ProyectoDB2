using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoDB2
{
    public partial class PaginaPrincipal : Form
    {
        public PaginaPrincipal()
        {
            InitializeComponent();
        }

        private void PaginaPrincipal_Load(object sender, EventArgs e)
        {
            // TODO: Cambiar al arbol de DB2 cuando ya estemos en ese paso
            ConstruirArbolMock();
            AplicarModoEditor(ModoEditor.SQL);

            //TODO: ConstruirArbolDesdeDB2();
        }

        private enum ModoEditor
        {
            SQL,
            DDL
        }

        private ModoEditor modoActual = ModoEditor.SQL;

        // Guardamos el último DDL generado para poder volver a él con el botón DDL
        private string ultimoDDLGenerado = "Selecciona una tabla o vista para ver su DDL.";

        private string sqlActual = "";


        private void AplicarModoEditor(ModoEditor modo)
        {
            // Antes de cambiar de modo, guardamos lo que el usuario estaba escribiendo
            if (modoActual == ModoEditor.SQL)
            {
                sqlActual = richTxtBoxSQL.Text;
            }

            modoActual = modo;

            if (modo == ModoEditor.SQL)
            {
                richTxtBoxSQL.ReadOnly = false;

                // Mostrar el SQL que el usuario llevaba (o vacío si nunca escribió)
                richTxtBoxSQL.Text = sqlActual;

                // Para que se note el cambio
                richTxtBoxSQL.Focus();
                richTxtBoxSQL.SelectionStart = richTxtBoxSQL.TextLength;
            }
            else // DDL
            {
                richTxtBoxSQL.ReadOnly = true;

                // Mostrar el último DDL generado
                richTxtBoxSQL.Text = ultimoDDLGenerado;

                richTxtBoxSQL.Focus();
                richTxtBoxSQL.SelectionStart = 0;
            }
            ActualizarEstadoBotonesModo();

            toolTipEjecutar.Enabled = (modoActual == ModoEditor.SQL);
        }



        // PASO 1: Construir el TreeView con estructura mock
        private void ConstruirArbolMock()
        {
            treeView1.BeginUpdate();
            try
            {
                treeView1.Nodes.Clear();

                // Raíz
                TreeNode nodoConexiones = CrearNodo(
                    "Conexiones",
                    new InfoNodoBD { Tipo = TipoObjetoBD.Carpeta, Nombre = "Conexiones" }
                );

                // Conexión
                TreeNode nodoConexion = CrearNodo(
                    "DB2_Local",
                    new InfoNodoBD { Tipo = TipoObjetoBD.Conexion, Nombre = "DB2_Local" }
                );

                // Bases de datos
                TreeNode nodoBasesDatos = CrearNodo(
                    "Bases de Datos",
                    new InfoNodoBD { Tipo = TipoObjetoBD.Carpeta, Nombre = "Bases de Datos" }
                );

                // Base de datos
                TreeNode nodoBase = CrearNodo(
                    "SAMPLE",
                    new InfoNodoBD { Tipo = TipoObjetoBD.BaseDeDatos, Nombre = "SAMPLE" }
                );

                // Esquemas
                TreeNode nodoEsquemas = CrearNodo(
                    "Esquemas",
                    new InfoNodoBD { Tipo = TipoObjetoBD.Carpeta, Nombre = "Esquemas" }
                );

                // Esquema
                TreeNode nodoEsquema = CrearNodo(
                    "DB2INST1",
                    new InfoNodoBD { Tipo = TipoObjetoBD.Esquema, Nombre = "DB2INST1" }
                );

                // Tablas
                TreeNode nodoTablas = CrearNodo(
                    "Tablas",
                    new InfoNodoBD { Tipo = TipoObjetoBD.Carpeta, Nombre = "Tablas", Esquema = "DB2INST1" }
                );
                nodoTablas.Nodes.Add(CrearNodo("EMPLOYEE", new InfoNodoBD { Tipo = TipoObjetoBD.Tabla, Nombre = "EMPLOYEE", Esquema = "DB2INST1" }));
                nodoTablas.Nodes.Add(CrearNodo("DEPARTMENT", new InfoNodoBD { Tipo = TipoObjetoBD.Tabla, Nombre = "DEPARTMENT", Esquema = "DB2INST1" }));

                // Vistas
                TreeNode nodoVistas = CrearNodo(
                    "Vistas",
                    new InfoNodoBD { Tipo = TipoObjetoBD.Carpeta, Nombre = "Vistas", Esquema = "DB2INST1" }
                );
                nodoVistas.Nodes.Add(CrearNodo("V_EMPLOYEE", new InfoNodoBD { Tipo = TipoObjetoBD.Vista, Nombre = "V_EMPLOYEE", Esquema = "DB2INST1" }));

                // Otros objetos (carpetas vacías por ahora)
                TreeNode nodoProcedimientos = CrearNodo("Procedimientos", new InfoNodoBD { Tipo = TipoObjetoBD.Carpeta, Nombre = "Procedimientos", Esquema = "DB2INST1" });
                TreeNode nodoFunciones = CrearNodo("Funciones", new InfoNodoBD { Tipo = TipoObjetoBD.Carpeta, Nombre = "Funciones", Esquema = "DB2INST1" });
                TreeNode nodoTriggers = CrearNodo("Triggers", new InfoNodoBD { Tipo = TipoObjetoBD.Carpeta, Nombre = "Triggers", Esquema = "DB2INST1" });
                TreeNode nodoIndices = CrearNodo("Índices", new InfoNodoBD { Tipo = TipoObjetoBD.Carpeta, Nombre = "Índices", Esquema = "DB2INST1" });
                TreeNode nodoSecuencias = CrearNodo("Secuencias", new InfoNodoBD { Tipo = TipoObjetoBD.Carpeta, Nombre = "Secuencias", Esquema = "DB2INST1" });
                TreeNode nodoPaquetes = CrearNodo("Paquetes", new InfoNodoBD { Tipo = TipoObjetoBD.Carpeta, Nombre = "Paquetes", Esquema = "DB2INST1" });
                TreeNode nodoTablespaces = CrearNodo("Tablespaces", new InfoNodoBD { Tipo = TipoObjetoBD.Carpeta, Nombre = "Tablespaces", Esquema = "DB2INST1" });
                TreeNode nodoUsuarios = CrearNodo("Usuarios", new InfoNodoBD { Tipo = TipoObjetoBD.Carpeta, Nombre = "Usuarios", Esquema = "DB2INST1" });

                // Ensamble dentro del esquema
                nodoEsquema.Nodes.Add(nodoTablas);
                nodoEsquema.Nodes.Add(nodoVistas);
                nodoEsquema.Nodes.Add(nodoProcedimientos);
                nodoEsquema.Nodes.Add(nodoFunciones);
                nodoEsquema.Nodes.Add(nodoTriggers);
                nodoEsquema.Nodes.Add(nodoIndices);
                nodoEsquema.Nodes.Add(nodoSecuencias);
                nodoEsquema.Nodes.Add(nodoPaquetes);
                nodoEsquema.Nodes.Add(nodoTablespaces);
                nodoEsquema.Nodes.Add(nodoUsuarios);

                // Ensamble final del árbol
                nodoEsquemas.Nodes.Add(nodoEsquema);
                nodoBase.Nodes.Add(nodoEsquemas);
                nodoBasesDatos.Nodes.Add(nodoBase);
                nodoConexion.Nodes.Add(nodoBasesDatos);
                nodoConexiones.Nodes.Add(nodoConexion);

                treeView1.Nodes.Add(nodoConexiones);

                // Expand inicial (para que se vea listo)
                nodoConexiones.Expand();
                nodoConexion.Expand();
                nodoBasesDatos.Expand();
                nodoBase.Expand();
                nodoEsquemas.Expand();
                nodoEsquema.Expand();
            }
            finally
            {
                treeView1.EndUpdate();
            }
        }

        private TreeNode CrearNodo(string texto, InfoNodoBD info)
        {
            TreeNode nodo = new TreeNode(texto);
            nodo.Tag = info;
            return nodo;
        }

        // Info mínima guardada en Tag (PASO 1)
        private enum TipoObjetoBD
        {
            Carpeta,
            Conexion,
            BaseDeDatos,
            Esquema,
            Tabla,
            Vista,
            Procedimiento,
            Funcion,
            Trigger,
            Indice,
            Secuencia,
            Paquete,
            Tablespace,
            Usuario
        }

        private class InfoNodoBD
        {
            public TipoObjetoBD Tipo { get; set; }
            public string Nombre { get; set; }
            public string Esquema { get; set; }
        }

        private void MostrarDDL(string ddl)
        {
            ultimoDDLGenerado = ddl;
            AplicarModoEditor(ModoEditor.DDL);
        }
        private void ActualizarEstadoBotonesModo()
        {
            if (modoActual == ModoEditor.SQL)
            {
                btnSQL.Enabled = false;
                btnDDL.Enabled = true;
            }
            else // DDL
            {
                btnSQL.Enabled = true;
                btnDDL.Enabled = false;
            }
        }


        private string GenerarDDLMOCK_Tabla(string esquema, string nombreTabla)
        {
            if (string.IsNullOrWhiteSpace(esquema)) esquema = "DB2INST1";
            if (string.IsNullOrWhiteSpace(nombreTabla)) nombreTabla = "TABLA";

            return
                    $@"CREATE TABLE {esquema}.{nombreTabla} (
                ID INT NOT NULL,
                NOMBRE VARCHAR(100),
                FECHA_CREACION TIMESTAMP,
                PRIMARY KEY (ID)
            );";
        }

        private string GenerarDDLMOCK_Vista(string esquema, string nombreVista)
        {
            if (string.IsNullOrWhiteSpace(esquema)) esquema = "DB2INST1";
            if (string.IsNullOrWhiteSpace(nombreVista)) nombreVista = "VISTA";

            return
                $@"CREATE VIEW {esquema}.{nombreVista} AS
                SELECT *
                FROM {esquema}.EMPLOYEE;";
        }

        private void btnSQL_Click(object sender, EventArgs e)
        {
            AplicarModoEditor(ModoEditor.SQL);
        }

        private void btnDDL_Click(object sender, EventArgs e)
        {
            AplicarModoEditor(ModoEditor.DDL);
        }

        private void toolTipEjecutar_Click(object sender, EventArgs e)
        {
            if (modoActual == ModoEditor.DDL)
            {
                EscribirMensaje("Estás en modo DDL. Usa 'Exportar DDL a SQL' para editar y ejecutar.");
                return;
            }

            string sql = sqlActual?.Trim();

            if (string.IsNullOrWhiteSpace(sql))
            {
                EscribirMensaje("No hay ninguna sentencia SQL para ejecutar.");
                return;
            }

            if (sql.StartsWith("select", StringComparison.OrdinalIgnoreCase))
            {
                CargarResultadosMock();
                EscribirMensaje("SELECT ejecutado correctamente (mock).");
            }
            else
            {
                EscribirMensaje("Sentencia ejecutada correctamente (mock).");
            }

        }

        private void toolTipLimpiar_Click(object sender, EventArgs e)
        {
            dataGridResultados.DataSource = null;
            richTxtBoxMensajes.Clear();
        }

        private void toolTipExport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ultimoDDLGenerado))
            {
                EscribirMensaje("No hay DDL para exportar.");
                return;
            }

            sqlActual = ultimoDDLGenerado;
            AplicarModoEditor(ModoEditor.SQL);

            EscribirMensaje("DDL exportado al editor SQL.");
        }

        private void toolTipNuevoQuery_Click(object sender, EventArgs e)
        {
            sqlActual = "";
            AplicarModoEditor(ModoEditor.SQL);
            richTxtBoxSQL.Clear();

            EscribirMensaje("Nuevo query iniciado.");
        }

        private void EscribirMensaje(string texto)
        {
            richTxtBoxMensajes.AppendText($"[{DateTime.Now:HH:mm:ss}] {texto}\n");
            richTxtBoxMensajes.ScrollToCaret();
            IrATabMensajes();
        }
        private void CargarResultadosMock()
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("ID", typeof(int));
            tabla.Columns.Add("NOMBRE", typeof(string));
            tabla.Columns.Add("FECHA", typeof(DateTime));

            tabla.Rows.Add(1, "Ejemplo 1", DateTime.Now);
            tabla.Rows.Add(2, "Ejemplo 2", DateTime.Now.AddMinutes(-10));
            tabla.Rows.Add(3, "Ejemplo 3", DateTime.Now.AddHours(-1));

            dataGridResultados.DataSource = tabla;
            tabResultados.SelectedTab = tpResultados;
        }

        private void MostrarResultados(DataTable tabla)
        {
            if (tabla == null || tabla.Rows.Count == 0)
            {
                // D) No hay resultados
                dataGridResultados.DataSource = null; // opcional, para que no se vea data vieja
                EscribirMensaje("La consulta no devolvió resultados.");
                return;
            }

            // C) Sí hay resultados
            dataGridResultados.DataSource = tabla;
            IrATabResultados();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                treeView1.SelectedNode = e.Node;
            }
        }

        private void menuTreeView_Opening(object sender, CancelEventArgs e)
        {
            TreeNode nodo = treeView1.SelectedNode;
            if (nodo == null || nodo.Tag is not InfoNodoBD info)
            {
                // Nada seleccionado o sin info: cancelar el menú
                e.Cancel = true;
                return;
            }

            bool esTabla = info.Tipo == TipoObjetoBD.Tabla;
            bool esVista = info.Tipo == TipoObjetoBD.Vista;

            // Ver DDL y Exportar solo si es tabla o vista
            verDDLToolStripMenuItem.Enabled = esTabla || esVista;
            exportarDDLToolStripMenuItem.Enabled = esTabla || esVista;

            // Select *: solo para tabla o vista (lo dejamos en ambos)
            selectToolStripMenuItem.Enabled = esTabla || esVista;

            // Crear: por ahora solo lo habilitamos en carpetas relevantes (opcional)
            // Si no querés aún, déjalo deshabilitado siempre:
            crearToolStripMenuItem.Enabled = false;
        }

        private void verDDLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode?.Tag is not InfoNodoBD info) return;

            if (info.Tipo == TipoObjetoBD.Tabla)
            {
                MostrarDDL(GenerarDDLMOCK_Tabla(info.Esquema, info.Nombre));
            }
            else if (info.Tipo == TipoObjetoBD.Vista)
            {
                MostrarDDL(GenerarDDLMOCK_Vista(info.Esquema, info.Nombre));
            }
        }

        private void exportarDDLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode?.Tag is not InfoNodoBD info) return;

            // Generar DDL del nodo seleccionado
            string ddl = "";

            if (info.Tipo == TipoObjetoBD.Tabla)
                ddl = GenerarDDLMOCK_Tabla(info.Esquema, info.Nombre);
            else if (info.Tipo == TipoObjetoBD.Vista)
                ddl = GenerarDDLMOCK_Vista(info.Esquema, info.Nombre);

            if (string.IsNullOrWhiteSpace(ddl)) return;

            ultimoDDLGenerado = ddl;
            sqlActual = ddl;
            AplicarModoEditor(ModoEditor.SQL);

            EscribirMensaje("DDL exportado al editor SQL.");
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode?.Tag is not InfoNodoBD info) return;

            if (info.Tipo != TipoObjetoBD.Tabla && info.Tipo != TipoObjetoBD.Vista) return;

            string esquema = string.IsNullOrWhiteSpace(info.Esquema) ? "DB2INST1" : info.Esquema;
            string nombre = info.Nombre;

            sqlActual = $"SELECT * FROM {esquema}.{nombre} FETCH FIRST 100 ROWS ONLY;";
            AplicarModoEditor(ModoEditor.SQL);

            EscribirMensaje("Query de SELECT generada en el editor SQL.");
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            if (e.Node == null) return;

            if (e.Node.Tag is not InfoNodoBD info) return;

            if (info.Tipo == TipoObjetoBD.Tabla)
            {
                MostrarDDL(GenerarDDLMOCK_Tabla(info.Esquema, info.Nombre));
                return;
            }

            if (info.Tipo == TipoObjetoBD.Vista)
            {
                MostrarDDL(GenerarDDLMOCK_Vista(info.Esquema, info.Nombre));
                return;
            }
        }
        private void IrATabMensajes()
        {
            tabResultados.SelectedTab = tpMensajes;
        }

        private void IrATabResultados()
        {
            tabResultados.SelectedTab = tpResultados;
        }

    }
}
