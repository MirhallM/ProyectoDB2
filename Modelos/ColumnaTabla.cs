using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDB2.Modelos
{
    public class ColumnaTabla
    {
        public string Nombre { get; set; } = "";
        public string Tipo { get; set; } = "INTEGER";
        public int? Longitud { get; set; }
        public int? Escala { get; set; }
        public bool NotNull { get; set; }
        public bool EsPrimaryKey { get; set; }
        public bool EsIdentity { get; set; }
        public string Default { get; set; } = "";
    }
}