using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beans
{
    public class OrdenPedido
    {
        public long idOrdenPedido { get; set; }
        public Negocio negocio { get; set; }
        public Usuario usuarioSolicita { get; set; }
        public Usuario usuarioRespuesta { get; set; }
        public string totalSoles { get; set; }
        public Estado estado { get; set; }
        public string fechaRegistro { get; set; }
        public string fechaCambioEstado { get; set; }
        public string detalleRespuesta { get; set; }
        public string descripcion { get; set; }
    }
}
