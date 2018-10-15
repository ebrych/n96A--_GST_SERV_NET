using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beans
{
    public class Material
    {
        public int idMaterial { get; set; }
        public string descripcion { get; set; }
        public Tipo tipo { get; set; }
        public string unidad { get; set; }
        public string fechaRegistro { get; set; }
        public string fechaModificacion { get; set; }
        public Estado estado { get; set; }
}
}
