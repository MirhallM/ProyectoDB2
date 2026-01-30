using IBM.Data.Db2;

namespace ProyectoDB2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnProbarConexion_Click(object sender, EventArgs e)
        {
            try
            {
                GestorConexionDb2 gestor = new GestorConexionDb2();

                string sql =
                    "select tabname, tabschema, type " +
                    "from syscat.tables " +
                    "order by tabschema, tabname";

                TablaResultados.DataSource = gestor.EjecutarConsulta(sql);

                MessageBox.Show("Conexión realizada correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con DB2:\n" + ex.Message);
            }
        }
    }
}
