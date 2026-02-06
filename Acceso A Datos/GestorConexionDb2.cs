using IBM.Data.Db2;
using System.Data;

namespace ProyectoDB2
{
    public class GestorConexionDb2
    {
        private string cadenaConexion;

        public GestorConexionDb2()
        {
            cadenaConexion =
                "Server=localhost:50000;" +
                "Database=PROJDB;" +
                "UID=db2inst1;" +
                "PWD=contra;";
        }

        public DataTable EjecutarConsulta(string sql)
        {
            DB2Connection conexion = new DB2Connection(cadenaConexion);
            DB2Command comando = new DB2Command(sql, conexion);
            DB2DataAdapter adaptador = new DB2DataAdapter(comando);

            DataTable tabla = new DataTable();

            conexion.Open();
            adaptador.Fill(tabla);
            conexion.Close();

            return tabla;
        }
    }
}
