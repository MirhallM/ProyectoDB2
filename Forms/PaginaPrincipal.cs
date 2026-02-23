using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ProyectoDB2.Modelos;

namespace ProyectoDB2
{
    public partial class PaginaPrincipal : Form
    {
        private readonly GestorConexionDb2? gestorConexion;
        private readonly GestorMetadatosDb2? gestorMetadatos;

        public PaginaPrincipal()
        {
            InitializeComponent();
        }

        public PaginaPrincipal(GestorConexionDb2 gestor)
        {
            InitializeComponent();
            gestorConexion = gestor;
            gestorMetadatos = new GestorMetadatosDb2(gestor);
        }

        private void PaginaPrincipal_Load(object sender, EventArgs e)
        {
            AplicarModoEditor(ModoEditor.SQL);

            if (gestorConexion == null || gestorMetadatos == null)
            {
                EscribirMensaje("No hay conexión activa a DB2. Regresa al login.");
                return;
            }

            try
            {
                gestorMetadatos.ConstruirArbol(treeView1, EscribirMensaje);
            }
            catch (Exception ex)
            {
                EscribirMensaje("Error al construir el árbol: " + ex.Message);
            }
        }

        private enum ModoEditor
        {
            SQL,
            DDL
        }

        private ModoEditor modoActual = ModoEditor.SQL;

        private string ultimoDDLGenerado = "Selecciona una tabla o vista para ver su DDL.";
        private string sqlActual = "";

        private void AplicarModoEditor(ModoEditor modo)
        {
            // Solo guardamos el SQL si estamos SALIENDO del modo SQL
            if (modoActual == ModoEditor.SQL && modo != ModoEditor.SQL)
                sqlActual = richTxtBoxSQL.Text;

            modoActual = modo;

            if (modo == ModoEditor.SQL)
            {
                richTxtBoxSQL.ReadOnly = false;
                richTxtBoxSQL.Text = sqlActual;
                richTxtBoxSQL.Focus();
                richTxtBoxSQL.SelectionStart = richTxtBoxSQL.TextLength;
            }
            else
            {
                richTxtBoxSQL.ReadOnly = true;
                richTxtBoxSQL.Text = ultimoDDLGenerado;
                richTxtBoxSQL.Focus();
                richTxtBoxSQL.SelectionStart = 0;
            }

            ActualizarEstadoBotonesModo();
            toolTipEjecutar.Enabled = (modoActual == ModoEditor.SQL);
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
            else
            {
                btnSQL.Enabled = true;
                btnDDL.Enabled = false;
            }
        }

        private void btnSQL_Click(object sender, EventArgs e) => AplicarModoEditor(ModoEditor.SQL);
        private void btnDDL_Click(object sender, EventArgs e) => AplicarModoEditor(ModoEditor.DDL);

        private void richTxtBoxSQL_TextChanged(object sender, EventArgs e)
        {
            if (modoActual == ModoEditor.SQL)
                sqlActual = richTxtBoxSQL.Text;
        }


        private bool EsConsultaSelect(string sql)
        {
            if (string.IsNullOrWhiteSpace(sql)) return false;

            string s = sql.TrimStart();

            while (s.StartsWith("--"))
            {
                int salto = s.IndexOf('\n');
                if (salto < 0) return false;
                s = s.Substring(salto + 1).TrimStart();
            }

            return s.StartsWith("select", StringComparison.OrdinalIgnoreCase)
                || s.StartsWith("with", StringComparison.OrdinalIgnoreCase);
        }

        private void toolTipEjecutar_Click(object sender, EventArgs e)
        {
            if (modoActual == ModoEditor.DDL)
            {
                EscribirMensaje("Estás en modo DDL. Usa 'Exportar DDL a SQL' para editar y ejecutar.");
                return;
            }

            if (gestorConexion == null)
            {
                EscribirMensaje("No hay conexión activa a DB2. Regresa al login.");
                return;
            }

            sqlActual = richTxtBoxSQL.Text;
            string sql = sqlActual.Trim();

            if (string.IsNullOrWhiteSpace(sql))
            {
                EscribirMensaje("No hay ninguna sentencia SQL para ejecutar.");
                return;
            }

            try
            {
                if (EsConsultaSelect(sql))
                {
                    DataTable tabla = gestorConexion.EjecutarConsulta(sql);
                    MostrarResultados(tabla);
                }
                else
                {
                    int filas = gestorConexion.EjecutarComando(sql);
                    dataGridResultados.DataSource = null;
                    EscribirMensaje($"Sentencia ejecutada correctamente. Filas afectadas: {filas}");
                }
            }
            catch (Exception ex)
            {
                dataGridResultados.DataSource = null;
                EscribirMensaje("Error al ejecutar SQL: " + ex.Message);
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


        private void MostrarResultados(DataTable tabla)
        {
            if (tabla == null || tabla.Rows.Count == 0)
            {
                dataGridResultados.DataSource = null;
                EscribirMensaje("La consulta no devolvió resultados.");
                return;
            }

            dataGridResultados.DataSource = tabla;
            tabResultados.SelectedTab = tpResultados;
        }

        private void EscribirMensaje(string texto)
        {
            richTxtBoxMensajes.AppendText($"[{DateTime.Now:HH:mm:ss}] {texto}\n");
            richTxtBoxMensajes.ScrollToCaret();
            tabResultados.SelectedTab = tpMensajes;
        }


        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                treeView1.SelectedNode = e.Node;
        }

        private void menuTreeView_Opening(object sender, CancelEventArgs e)
        {
            TreeNode nodo = treeView1.SelectedNode;
            if (nodo == null || nodo.Tag is not InfoNodoBD info)
            {
                e.Cancel = true;
                return;
            }

            bool permiteDDL = info.Tipo switch
            {
                TipoObjetoBD.Tabla => true,
                TipoObjetoBD.Vista => true,
                TipoObjetoBD.Indice => true,
                TipoObjetoBD.Secuencia => true,
                TipoObjetoBD.Trigger => true,
                _ => false
            };

            bool permiteSelect = info.Tipo switch
            {
                TipoObjetoBD.Tabla => true,
                TipoObjetoBD.Vista => true,
                _ => false
            };

            bool esCarpeta = info.Tipo == TipoObjetoBD.Carpeta;
            bool esTablas = esCarpeta && nodo.Text.Trim().Equals("Tablas", StringComparison.OrdinalIgnoreCase);
            bool esVistas = esCarpeta && nodo.Text.Trim().Equals("Vistas", StringComparison.OrdinalIgnoreCase);

            verDDLToolStripMenuItem.Enabled = permiteDDL;
            exportarDDLToolStripMenuItem.Enabled = permiteDDL;
            selectToolStripMenuItem.Enabled = permiteSelect;

            crearToolStripMenuItem.Enabled = esTablas || esVistas;
        }

        private void verDDLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gestorMetadatos == null) return;
            if (treeView1.SelectedNode?.Tag is not InfoNodoBD info) return;

            string ddl = info.Tipo switch
            {
                TipoObjetoBD.Tabla => gestorMetadatos.ObtenerDDLTabla(info.Esquema, info.Nombre),
                TipoObjetoBD.Vista => gestorMetadatos.ObtenerDDLVista(info.Esquema, info.Nombre),
                TipoObjetoBD.Indice => gestorMetadatos.ObtenerDDLIndice(info.Esquema, info.Nombre),
                TipoObjetoBD.Secuencia => gestorMetadatos.ObtenerDDLSecuencia(info.Esquema, info.Nombre),
                TipoObjetoBD.Trigger => gestorMetadatos.ObtenerDDLTrigger(info.Esquema, info.Nombre),
                _ => ""
            };

            if (string.IsNullOrWhiteSpace(ddl)) return;

            MostrarDDL(ddl);
        }

        private void exportarDDLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gestorMetadatos == null) return;
            if (treeView1.SelectedNode?.Tag is not InfoNodoBD info) return;

            string ddl = info.Tipo switch
            {
                TipoObjetoBD.Tabla => gestorMetadatos.ObtenerDDLTabla(info.Esquema, info.Nombre),
                TipoObjetoBD.Vista => gestorMetadatos.ObtenerDDLVista(info.Esquema, info.Nombre),
                TipoObjetoBD.Indice => gestorMetadatos.ObtenerDDLIndice(info.Esquema, info.Nombre),
                TipoObjetoBD.Secuencia => gestorMetadatos.ObtenerDDLSecuencia(info.Esquema, info.Nombre),
                TipoObjetoBD.Trigger => gestorMetadatos.ObtenerDDLTrigger(info.Esquema, info.Nombre),
                _ => ""
            };

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

            string esquema = string.IsNullOrWhiteSpace(info.Esquema) ? "DB2INST1" : info.Esquema.Trim();
            string nombre = info.Nombre.Trim();

            sqlActual = $"SELECT * FROM {esquema}.{nombre} FETCH FIRST 100 ROWS ONLY;";
            AplicarModoEditor(ModoEditor.SQL);

            EscribirMensaje("Query de SELECT generada en el editor SQL.");
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            if (e.Node?.Tag is not InfoNodoBD info) return;
            if (gestorMetadatos == null) return;

            string ddl = info.Tipo switch
            {
                TipoObjetoBD.Tabla => gestorMetadatos.ObtenerDDLTabla(info.Esquema, info.Nombre),
                TipoObjetoBD.Vista => gestorMetadatos.ObtenerDDLVista(info.Esquema, info.Nombre),
                TipoObjetoBD.Indice => gestorMetadatos.ObtenerDDLIndice(info.Esquema, info.Nombre),
                TipoObjetoBD.Secuencia => gestorMetadatos.ObtenerDDLSecuencia(info.Esquema, info.Nombre),
                TipoObjetoBD.Trigger => gestorMetadatos.ObtenerDDLTrigger(info.Esquema, info.Nombre),
                _ => ""
            };

            if (string.IsNullOrWhiteSpace(ddl)) return;

            MostrarDDL(ddl);
        }

        private void PaginaPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void toolTipRefrescar_Click(object sender, EventArgs e)
        {
            if (gestorConexion == null || gestorMetadatos == null)
            {
                EscribirMensaje("No hay conexión activa. No se puede refrescar el navegador.");
                return;
            }

            try
            {
                gestorMetadatos.ConstruirArbol(treeView1, EscribirMensaje);
                EscribirMensaje("Navegador actualizado.");
            }
            catch (Exception ex)
            {
                EscribirMensaje("Error al refrescar el navegador: " + ex.Message);
            }

        }

        private List<string> ObtenerEsquemasDesdeTreeView()
        {
            List<string> esquemas = new List<string>();

            // Buscamos: Conexiones -> DB2_Actual -> Esquemas -> (APP, etc)
            TreeNode? nodoConexiones = treeView1.Nodes.Count > 0 ? treeView1.Nodes[0] : null;
            if (nodoConexiones == null) return esquemas;

            TreeNode? nodoConexion = (nodoConexiones.Nodes.Count > 0) ? nodoConexiones.Nodes[0] : null;
            if (nodoConexion == null) return esquemas;

            TreeNode? nodoEsquemas = null;
            foreach (TreeNode n in nodoConexion.Nodes)
            {
                if (n.Text.Trim().Equals("Esquemas", StringComparison.OrdinalIgnoreCase))
                {
                    nodoEsquemas = n;
                    break;
                }
            }

            if (nodoEsquemas == null) return esquemas;

            foreach (TreeNode n in nodoEsquemas.Nodes)
            {
                string esq = n.Text.Trim();
                if (!string.IsNullOrWhiteSpace(esq))
                    esquemas.Add(esq);
            }

            // Quitar repetidos y ordenar
            esquemas = esquemas
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(x => x)
                .ToList();

            return esquemas;
        }

        private string ObtenerEsquemaContexto(TreeNode? nodo)
        {
            if (nodo == null) return "";

            // Si el nodo tiene Tag InfoNodoBD y trae Esquema, lo usamos
            if (nodo.Tag is InfoNodoBD info && !string.IsNullOrWhiteSpace(info.Esquema))
                return info.Esquema.Trim();

            // Si no, subimos hacia arriba hasta encontrar uno que tenga Esquema
            TreeNode? actual = nodo.Parent;
            while (actual != null)
            {
                if (actual.Tag is InfoNodoBD info2 && !string.IsNullOrWhiteSpace(info2.Esquema))
                    return info2.Esquema.Trim();

                actual = actual.Parent;
            }

            return "";
        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null) return;

            string textoNodo = treeView1.SelectedNode.Text.Trim();

            // Solo permitir crear cuando esté en la carpeta "Tablas"
            if (!textoNodo.Equals("Tablas", StringComparison.OrdinalIgnoreCase))
            {
                EscribirMensaje("Para crear una tabla, hacé clic derecho sobre la carpeta 'Tablas'.");
                return;
            }

            // Obtener esquema del contexto
            string esquemaContexto = ObtenerEsquemaContexto(treeView1.SelectedNode);

            // Lista de esquemas
            List<string> esquemas = ObtenerEsquemasDesdeTreeView();

            if (!string.IsNullOrWhiteSpace(esquemaContexto))
            {
                esquemas.RemoveAll(x => x.Equals(esquemaContexto, StringComparison.OrdinalIgnoreCase));
                esquemas.Insert(0, esquemaContexto);
            }

            // Abrir Paso 1
            using (var paso1 = new ProyectoDB2.Forms.CrearTablaPaso1(esquemas))
            {
                var resPaso1 = paso1.ShowDialog(this);

                if (resPaso1 != DialogResult.OK)
                {
                    EscribirMensaje("Creación de tabla cancelada.");
                    return;
                }

                // Si todo salió bien, paso1 ya trae el DDL generado por paso2
                string ddl = paso1.DdlGenerado;

                if (string.IsNullOrWhiteSpace(ddl))
                {
                    EscribirMensaje("No se generó el DDL.");
                    return;
                }

                // Mandarlo al editor SQL
                sqlActual = ddl;
                AplicarModoEditor(ModoEditor.SQL);

                EscribirMensaje("DDL de CREATE TABLE generado por el wizard.");
            }
        }
    }
}
