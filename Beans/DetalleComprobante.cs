using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beans
{
    public class DetalleComprobante
    {
        public long idDetalleComprobante { get; set; }
        public Comprobante comprobante { get; set; }
        public Concepto concepto { get; set; }
        public int cantidad { get; set; }
        public decimal monto { get; set; }
        public string fechaRegistro { get; set; }
    }
}
