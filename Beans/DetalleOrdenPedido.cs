using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beans
{
    public class DetalleOrdenPedido
    {
        public long idDetalleOrdenPedido { get; set; }
        public OrdenPedido ordenPedido { get; set; }
        public Material material { get; set; }
        public int cantidad { get; set; }

    }
}
