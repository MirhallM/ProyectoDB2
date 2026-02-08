using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using IBM.Data.Db2; 

namespace ProyectoDB2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
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
    }
}
