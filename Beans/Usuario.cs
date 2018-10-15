using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beans
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string nombres { get; set; }
        public string mail { get; set; }
        public string token { get; set; }
        public Role role { get; set; }
        public Estado estado { get; set; }
    }
}
