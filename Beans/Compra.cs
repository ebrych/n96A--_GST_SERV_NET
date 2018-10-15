using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beans
{
    public class Compra
    {
        public long idCompra { get; set; }
        public string descripcion { get; set; }
        public Proveedor proveedor { get; set; }
        public string fecha { get; set; }
        public Usuario usuario { get; set; }
        public decimal montoTotal { get; set; }
        public Estado estado { get; set; }
    }  
}
