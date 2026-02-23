using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ProyectoDB2.Forms
{
    public partial class CrearVistaPaso1 : Form
    {
        // Opcional: si lo pasás desde PaginaPrincipal, cargamos tablas base del esquema
        private readonly GestorConexionDb2? gestorConexion;

        // Datos que el wizard va a ir pasando entre pantallas
        public string DdlGenerado { get; private set; } = "";

        public string EsquemaSeleccionado => cbEsquema.SelectedItem?.ToString() ?? "";
        public string NombreVista => tbNombreVista.Text ?? "";
        public string TablaBase => cbTablaBase.SelectedItem?.ToString() ?? "";

        // Constructor normal
        public CrearVistaPaso1()
        {
            InitializeComponent();
            btnAtras.Enabled = false;
        }

        // Constructor recomendado (igual que CrearTablaPaso1): recibe lista de esquemas
        // gestor es opcional para que lo puedas llamar solo con (esquemas)
        public CrearVistaPaso1(List<string> esquemas, GestorConexionDb2? gestor = null, string esquemaPorDefecto = "")
            : this()
        {
            gestorConexion = gestor;

            CargarEsquemas(esquemas);

            // Si querés que seleccione un esquema por defecto
            if (!string.IsNullOrWhiteSpace(esquemaPorDefecto))
            {
                for (int i = 0; i < cbEsquema.Items.Count; i++)
                {
                    string item = cbEsquema.Items[i]?.ToString() ?? "";
                    if (item.Equals(esquemaPorDefecto, StringComparison.OrdinalIgnoreCase))
                    {
                        cbEsquema.SelectedIndex = i;
                        break;
                    }
                }
            }

            // Si no hay gestor, no podemos cargar tablas base desde DB2
            if (gestorConexion == null)
            {
                cbTablaBase.Enabled = false;
            }
        }

        private void CargarEsquemas(List<string> esquemas)
        {
            cbEsquema.Items.Clear();

            if (esquemas == null || esquemas.Count == 0)
            {
                cbEsquema.Items.Add("APP");
                cbEsquema.SelectedIndex = 0;
                return;
            }

            var lista = esquemas
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x.Trim())
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(x => x)
                .ToList();

            foreach (var e in lista)
                cbEsquema.Items.Add(e);

            if (cbEsquema.Items.Count > 0)
                cbEsquema.SelectedIndex = 0;
        }

        private void CrearVistaPaso1_Load(object sender, EventArgs e)
        {
            // Solo cargar tablas si tenemos conexión
            if (gestorConexion != null)
                CargarTablasDelEsquemaActual();
        }

        private void cbEsquema_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gestorConexion != null)
                CargarTablasDelEsquemaActual();
        }

        private void CargarTablasDelEsquemaActual()
        {
            if (gestorConexion == null) return;

            cbTablaBase.Items.Clear();

            string esquema = EsquemaSeleccionado.Trim();
            if (string.IsNullOrWhiteSpace(esquema)) return;

            string esq = esquema.Replace("'", "''");

            DataTable dt = gestorConexion.EjecutarConsulta($@"
                SELECT TABNAME
                FROM SYSCAT.TABLES
                WHERE TABSCHEMA = '{esq}'
                  AND TYPE = 'T'
                ORDER BY TABNAME
            ");

            foreach (DataRow r in dt.Rows)
            {
                string nombre = (r["TABNAME"]?.ToString() ?? "").Trim();
                if (!string.IsNullOrWhiteSpace(nombre))
                    cbTablaBase.Items.Add(nombre);
            }

            if (cbTablaBase.Items.Count > 0)
                cbTablaBase.SelectedIndex = 0;
        }

        private bool NombreValido(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return false;

            nombre = nombre.Trim();

            if (char.IsDigit(nombre[0]))
                return false;

            foreach (char c in nombre)
            {
                bool ok = char.IsLetterOrDigit(c) || c == '_';
                if (!ok) return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (cbEsquema.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná un esquema.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombreVista = (tbNombreVista.Text ?? "").Trim();

            if (!NombreValido(nombreVista))
            {
                MessageBox.Show("El nombre de la vista no es válido. Usá letras, números y '_' (no puede empezar con número).",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbNombreVista.Focus();
                tbNombreVista.SelectAll();
                return;
            }

            // Solo validamos tabla base si el combo está habilitado (o sea, si hay gestorConexion)
            if (cbTablaBase.Enabled)
            {
                if (cbTablaBase.SelectedItem == null)
                {
                    MessageBox.Show("Seleccioná una tabla base.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // En este paso todavía no generamos el DDL completo.
            // DdlGenerado se llenará en el Paso 2 / Paso 3 del wizard.
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            // Paso 1 no usa Atrás, queda por consistencia del wizard
        }
    }
}