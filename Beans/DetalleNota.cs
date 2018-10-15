using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beans
{
    public class DetalleNota
    {
        public long idDetalleNota { get; set; }
        public Nota nota { get; set; }
        public Material material { get; set; }
        public int Cantidad { get; set; }
        public string fechaRegistro { get; set; }
    }
}
