using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beans
{
    public class Comprobante
    {
        public long idComprobante { get; set; }
        public string serie { get; set; }
        public string numeroComprobante { get; set; }
        public Negocio negocio { get; set; }
        public Cliente cliente { get; set; }
        public Tipo tipo { get; set; }
        public string fechaImprecion { get; set; }
        public string fechaPago { get; set; }
        public string descripcion { get; set; }
        public Estado estado { get; set; }
        public decimal subtotal { get; set; }
        public decimal igv { get; set; }
        public decimal total { get; set; }
    }
}
