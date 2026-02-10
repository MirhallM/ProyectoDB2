using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProyectoDB2.Acceso_A_Datos
{
    public class ConexionGuardada()
    {
        public string Nombre { get; set; } = "";
        public string Servidor { get; set; } = "";
        public string Puerto { get; set; } = "50000";
        public string BaseDeDatos { get; set; } = "";
    }

    public class GestorConexiones
    {
        private readonly string rutaArchivo;

        public GestorConexiones()
        {
            string carpeta = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ProyectoDB2");

            if(!Directory.Exists(carpeta)) Directory.CreateDirectory(carpeta);

            rutaArchivo = Path.Combine(carpeta, "conexiones.json");
        }

        public List<ConexionGuardada> Cargar()
        {
            try
            {
                if (!File.Exists(rutaArchivo))
                    return new List<ConexionGuardada>();

                string json = File.ReadAllText(rutaArchivo);

                var lista = JsonSerializer.Deserialize<List<ConexionGuardada>>(json);
                return lista ?? new List<ConexionGuardada>();
            }
            catch
            {
                return new List<ConexionGuardada>(); //Por si el archivo esta corrompido
            }
        }

        public void Guardar(List<ConexionGuardada> conexiones)
        {
            var opciones = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(conexiones, opciones);
            File.WriteAllText(rutaArchivo, json);
        }

        public bool ExisteNombre(List<ConexionGuardada> conexiones, string nombre, string? ignorarNombre = null)
        {
            string name = (nombre ?? "").Trim();
            if (name.Length == 0) return false;

            return conexiones.Any(c => c.Nombre.Equals(name, StringComparison.OrdinalIgnoreCase) && 
                (ignorarNombre == null || !c.Nombre.Equals(ignorarNombre, StringComparison.OrdinalIgnoreCase)));
        }
    }
}
