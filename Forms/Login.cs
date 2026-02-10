using IBM.Data.Db2; 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoDB2.Acceso_A_Datos;

namespace ProyectoDB2
{
    public partial class Login : Form
    {
        private GestorConexiones gestorConexiones = new GestorConexiones();
        private List<ConexionGuardada> conexiones = new List<ConexionGuardada>();

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            conexiones = gestorConexiones.Cargar();

            listaConexiones.DisplayMember = "Nombre";
            listaConexiones.ValueMember = "Nombre";
            listaConexiones.DataSource = null;
            listaConexiones.DataSource = conexiones;

            if (conexiones.Count > 0) listaConexiones.SelectedIndex = 0;
        }

        private void CargarConexionesGuardadas()
        {
            conexiones = gestorConexiones.Cargar();

            listaConexiones.DisplayMember = "Nombre";
            listaConexiones.ValueMember = "Nombre";
            listaConexiones.DataSource = null;
            listaConexiones.DataSource = conexiones;

            if (conexiones.Count > 0)
                listaConexiones.SelectedIndex = 0;
        }

        private ConexionGuardada LeerFormulario()
        {
            return new ConexionGuardada
            {
                Nombre = tbNombre.Text.Trim(),
                Servidor = tbServidor.Text.Trim(),
                Puerto = tbPuerto.Text.Trim(),
                BaseDeDatos = tbBDD.Text.Trim()
            };
        }

        private void EscribirFormulario(ConexionGuardada conexion)
        {
            tbNombre.Text = conexion.Nombre;
            tbServidor.Text = conexion.Servidor;
            tbPuerto.Text = conexion.Puerto;
            tbBDD.Text = conexion.BaseDeDatos;
        }

        private bool ValidarFormulario(out string error)
        {
            error = "";
            if (tbNombre.Text.Trim().Length == 0)
                error += "- El nombre de la conexión no puede estar vacío.\n";
            if (tbServidor.Text.Trim().Length == 0)
                error += "- El servidor no puede estar vacío.\n";
            if (tbPuerto.Text.Trim().Length == 0)
                error += "- El puerto no puede estar vacío.\n";
            else if (!int.TryParse(tbPuerto.Text.Trim(), out int puerto) || puerto <= 0)
                error += "- El puerto debe ser un número entero positivo.\n";
            if (tbBDD.Text.Trim().Length == 0)
                error += "- La base de datos no puede estar vacía.\n";
            return error.Length == 0;
        }

        private void listaConexiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listaConexiones.SelectedItem is ConexionGuardada conexion)
            {
                EscribirFormulario(conexion);
            }
        }
        private string ConstruirCadenaConexion()
        {
            string servidor = tbServidor.Text.Trim();
            string puerto = tbPuerto.Text.Trim();
            string baseDatos = tbBDD.Text.Trim();
            string usuario = tbUsuario.Text.Trim();
            string contra = tbContra.Text; // sin Trim

            return
                $"Server={servidor}:{puerto};" +
                $"Database={baseDatos};" +
                $"UID={usuario};" +
                $"PWD={contra};";
        }
        private void buttonProbarConexion_Click(object sender, EventArgs e)
        {
            try
            {
                string cadena = ConstruirCadenaConexion();
                GestorConexionDb2 gestor = new GestorConexionDb2(cadena);

                gestor.ProbarConexion();

                MessageBox.Show(
                    "Conexión exitosa a DB2.",
                    "Conexión OK",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo conectar a DB2.\n\n" + ex.Message,
                    "Error de conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnProbarConexion_Click(object sender, EventArgs e)
        {
            try
            {
                string cadena = ConstruirCadenaConexion();
                GestorConexionDb2 gestor = new GestorConexionDb2(cadena);

                gestor.ProbarConexion();

                MessageBox.Show(
                    "Conexión exitosa a DB2.",
                    "Conexión OK",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo conectar a DB2.\n\n" + ex.Message,
                    "Error de conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnGuardarConexion_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario(out string error))
            {
                MessageBox.Show(
                    "No se pudo guardar la conexión debido a los siguientes errores:\n\n" + error,
                    "Error de validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            ConexionGuardada nueva = LeerFormulario();

            int idx = conexiones.FindIndex(x => x.Nombre.Equals(nueva.Nombre, StringComparison.OrdinalIgnoreCase));

            if (idx >= 0)
            {
                conexiones[idx] = nueva;
            }
            else
            {
                if (gestorConexiones.ExisteNombre(conexiones, nueva.Nombre))
                {
                    MessageBox.Show("Ya existe una conexión con ese nombre. Por favor elige otro nombre.",
                        "Error de validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                conexiones.Add(nueva);
            }

            gestorConexiones.Guardar(conexiones);
            CargarConexionesGuardadas();

            MessageBox.Show("Conexión guardada exitosamente.",
                "Guardado OK",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                string cadena = ConstruirCadenaConexion();
                GestorConexionDb2 gestor = new GestorConexionDb2(cadena);

                // Validar conexión primero
                gestor.ProbarConexion();

                // Abrir main form con esa conexión
                PaginaPrincipal main = new PaginaPrincipal(gestor);
                main.Show();

                // Ocultar login
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo conectar a DB2.\n\n" + ex.Message,
                    "Error de conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (listaConexiones.SelectedItem is not ConexionGuardada conexion)
            {
                MessageBox.Show("No hay ninguna conexión seleccionada para eliminar.",
                    "Error de eliminación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"¿Estás seguro de que quieres eliminar la conexión '{conexion.Nombre}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.No) return;

            conexiones.RemoveAll(x => x.Nombre.Equals(conexion.Nombre, StringComparison.OrdinalIgnoreCase));
            gestorConexiones.Guardar(conexiones);
            CargarConexionesGuardadas();
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            tbNombre.Clear();
            tbServidor.Clear();
            tbPuerto.Clear();
            tbBDD.Clear();
            tbUsuario.Clear();
            tbContra.Clear();

            tbNombre.Focus();
        }
    }
}
