using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beans
{
    public class Kardex
    {
        public Material material { get; set; }
        public string fecha { get; set; }
        public int compras { get; set; }
        public int pedidos { get; set; }
        public int total { get; set; }
    }
}
