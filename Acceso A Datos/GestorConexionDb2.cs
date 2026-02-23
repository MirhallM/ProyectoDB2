using IBM.Data.Db2;
using System;
using System.Data;

namespace ProyectoDB2
{
    public class GestorConexionDb2
    {
        private string cadenaConexion;

        // Constructor por defecto para pruebas
        public GestorConexionDb2()
        {
            cadenaConexion =
                "Server=localhost:50000;" +
                "Database=PROJDB;" +
                "UID=db2inst1;" +
                "PWD=contra;";
        }

        
        public GestorConexionDb2(string cadenaConexion)
        {
            this.cadenaConexion = cadenaConexion;
        }

        
        public void ProbarConexion()
        {
            using (DB2Connection conexion = new DB2Connection(cadenaConexion))
            {
                conexion.Open();
                // Si abre sin excepción, la conexión es válida.
            }
        }

        public DataTable EjecutarConsulta(string sql)
        {
            using (DB2Connection conexion = new DB2Connection(cadenaConexion))
            using (DB2Command comando = new DB2Command(sql, conexion))
            using (DB2DataAdapter adaptador = new DB2DataAdapter(comando))
            {
                DataTable tabla = new DataTable();
                conexion.Open();
                adaptador.Fill(tabla);
                return tabla;
            }
        }

        public int EjecutarComando(string sql)
        {
            using (DB2Connection conexion = new DB2Connection(cadenaConexion))
            using (DB2Command comando = new DB2Command(sql, conexion))
            {
                conexion.Open();
                return comando.ExecuteNonQuery();
            }
        }

    }
}
