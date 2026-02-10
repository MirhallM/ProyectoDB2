using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDB2.Modelos
{
    public enum TipoObjetoBD
    {
        Carpeta,
        Conexion,
        BaseDeDatos,
        Esquema,
        Tabla,
        Vista,
        Procedimiento,
        Funcion,
        Trigger,
        Indice,
        Secuencia,
        Paquete,
        Tablespace,
        Usuario
    }

    public class InfoNodoBD
    {
        public TipoObjetoBD Tipo { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Esquema { get; set; } = string.Empty;
    }
}
