using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProyectoDB2.Forms
{
    public partial class CrearVistaPaso2 : Form
    {
        private readonly GestorConexionDb2 gestorConexion;
        private readonly string esquema;
        private readonly string nombreVista;
        private readonly string tablaBase;

        public string DdlGenerado { get; private set; } = "";

        public CrearVistaPaso2(GestorConexionDb2 gestor, string esquemaSeleccionado, string nombreVista, string tablaBase)
        {
            InitializeComponent();

            gestorConexion = gestor;
            esquema = (esquemaSeleccionado ?? "").Trim();
            this.nombreVista = (nombreVista ?? "").Trim();
            this.tablaBase = (tablaBase ?? "").Trim();
        }

        private void CrearVistaPaso2_Load(object sender, EventArgs e)
        {
            CargarColumnas();

            // Estado inicial botones
            btnQuitar.Enabled = false;
            btnAgregar.Enabled = false;

            // Si agregaste botones "todo"
            if (btnAgregarTodo != null) btnAgregarTodo.Enabled = true;
            if (btnQuitarTodo != null) btnQuitarTodo.Enabled = true;
        }

        private void CargarColumnas()
        {
            lbDisponibles.Items.Clear();
            lbIncluidas.Items.Clear();

            if (string.IsNullOrWhiteSpace(esquema) || string.IsNullOrWhiteSpace(tablaBase))
                return;

            string esq = esquema.Replace("'", "''");
            string tab = tablaBase.Replace("'", "''");

            DataTable dt = gestorConexion.EjecutarConsulta($@"
                SELECT COLNAME
                FROM SYSCAT.COLUMNS
                WHERE TABSCHEMA = '{esq}'
                  AND TABNAME = '{tab}'
                ORDER BY COLNO
            ");

            foreach (DataRow r in dt.Rows)
            {
                string col = (r["COLNAME"]?.ToString() ?? "").Trim();
                if (!string.IsNullOrWhiteSpace(col))
                    lbDisponibles.Items.Add(col);
            }

            if (lbDisponibles.Items.Count > 0)
                lbDisponibles.SelectedIndex = 0;
        }

        private void lbDisponibles_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAgregar.Enabled = (lbDisponibles.SelectedItem != null);
        }

        private void lbIncluidas_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnQuitar.Enabled = (lbIncluidas.SelectedItem != null);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (lbDisponibles.SelectedItem == null) return;

            string col = lbDisponibles.SelectedItem.ToString() ?? "";
            if (string.IsNullOrWhiteSpace(col)) return;

            lbDisponibles.Items.Remove(col);

            if (!lbIncluidas.Items.Contains(col))
                lbIncluidas.Items.Add(col);

            btnAgregar.Enabled = (lbDisponibles.SelectedItem != null);
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (lbIncluidas.SelectedItem == null) return;

            string col = lbIncluidas.SelectedItem.ToString() ?? "";
            if (string.IsNullOrWhiteSpace(col)) return;

            lbIncluidas.Items.Remove(col);

            if (!lbDisponibles.Items.Contains(col))
                lbDisponibles.Items.Add(col);

            // Reordenar disponibles para que no quede feo
            ReordenarListBox(lbDisponibles);

            btnQuitar.Enabled = (lbIncluidas.SelectedItem != null);
        }

        private void btnAgregarTodo_Click(object sender, EventArgs e)
        {
            var todos = lbDisponibles.Items.Cast<object>().Select(x => x.ToString() ?? "").Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
            lbDisponibles.Items.Clear();

            foreach (var c in todos)
                if (!lbIncluidas.Items.Contains(c))
                    lbIncluidas.Items.Add(c);
        }

        private void btnQuitarTodo_Click(object sender, EventArgs e)
        {
            var todos = lbIncluidas.Items.Cast<object>().Select(x => x.ToString() ?? "").Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
            lbIncluidas.Items.Clear();

            foreach (var c in todos)
                if (!lbDisponibles.Items.Contains(c))
                    lbDisponibles.Items.Add(c);

            ReordenarListBox(lbDisponibles);
        }

        private void ReordenarListBox(ListBox lb)
        {
            var lista = lb.Items.Cast<object>().Select(x => x.ToString() ?? "").OrderBy(x => x, StringComparer.OrdinalIgnoreCase).ToList();
            lb.Items.Clear();
            foreach (var s in lista) lb.Items.Add(s);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            // Volvemos al paso 1 sin guardar nada aquí
            DialogResult = DialogResult.Retry;
            Close();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (lbIncluidas.Items.Count == 0)
            {
                MessageBox.Show("Seleccioná al menos una columna para la vista.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Construir SELECT
            var columnas = lbIncluidas.Items.Cast<object>()
                .Select(x => (x?.ToString() ?? "").Trim())
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList();

            string distinct = (chkDistinct != null && chkDistinct.Checked) ? "DISTINCT " : "";
            string selectCols = string.Join(",\n    ", columnas.Select(c => $"{esquema}.{tablaBase}.{c}"));

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CREATE VIEW {esquema}.{nombreVista} AS");
            sb.AppendLine($"SELECT {distinct}");
            sb.AppendLine("    " + selectCols);
            sb.AppendLine($"FROM {esquema}.{tablaBase};");

            DdlGenerado = sb.ToString();

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}