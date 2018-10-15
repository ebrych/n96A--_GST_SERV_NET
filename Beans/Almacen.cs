using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beans
{
    public class Almacen
    {
        public int idAlmacen { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string fechaRegistro { get; set; }
        public string fechaModificacion { get; set; }
        public Estado estado { get; set; }
    }
}
