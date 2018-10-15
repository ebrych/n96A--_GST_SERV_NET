using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beans
{
    public class Negocio
    {
        public long idNegocio { get; set; }
        public string nombre { get; set; }
        public Personal responsable { get; set; }
        public string descripcion { get; set; }
        public Tipo tipo { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFin { get; set; }
        public string fechaRegistro { get; set; }
        public Estado estado { get; set; }
        public string fechaModificacion { get; set; }
        public Cliente cliente { get; set; }
    }
}
