using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beans
{
    public class DetalleCompra
    {
        public long idCompraDetalle { get; set; }
        public Compra compra { get; set; }
        public Material material { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set;}
    }
}
