using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ProyectoDB2.Forms
{
    public partial class CrearTablaPaso1 : Form
    {
        // Datos que el wizard va a ir pasando entre pantallas
        public string DdlGenerado { get; private set; } = "";
        public string EsquemaSeleccionado => cbEsquema.SelectedItem?.ToString() ?? "";
        public string NombreTabla => tbNombreTabla.Text ?? "";

        // Constructor normal 
        public CrearTablaPaso1()
        {
            InitializeComponent();
            btnAtras.Enabled = false;
        }

        // Constructor recomendado: recibe la lista de esquemas desde PaginaPrincipal
        public CrearTablaPaso1(List<string> esquemas) : this()
        {
            CargarEsquemas(esquemas);
        }

        private void CargarEsquemas(List<string> esquemas)
        {
            cbEsquema.Items.Clear();

            // Ordenar y evitar repetidos
            var lista = esquemas
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x.Trim())
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(x => x)
                .ToList();

            foreach (var e in lista)
                cbEsquema.Items.Add(e);

            cbEsquema.SelectedIndex = 0;
        }

        private bool NombreTablaValido(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return false;

            // Regla simple: letras, numeros y _
            // y que no empiece con numero
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

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            string esquema = cbEsquema.SelectedItem?.ToString()?.Trim() ?? "";
            string nombreTabla = tbNombreTabla.Text.Trim();

            if (string.IsNullOrWhiteSpace(esquema))
            {
                MessageBox.Show("Seleccioná un esquema.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(nombreTabla))
            {
                MessageBox.Show("Escribí el nombre de la tabla.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var paso2 = new CrearTablaPaso2(esquema, nombreTabla))
            {
                var res = paso2.ShowDialog(this);

                if (res == DialogResult.Retry)
                    return;

                if (res != DialogResult.OK)
                    return;

                DdlGenerado = paso2.DdlGenerado;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CancelarYSalir();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            CancelarYSalir();
        }

        private void CancelarYSalir()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            //No se utiliza aqui
        }
    }
}