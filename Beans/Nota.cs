using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beans
{
    public class Nota
    {
        public long idNota { get; set; }
        public Tipo tipo { get; set; }
        public Almacen almacen { get; set; }
        public string descripcion { get; set; }
        public Usuario userSolicita { get; set; }
        public Usuario userResponde { get; set; }
        public string FechaSolicitud { get; set; }
        public string FechaRespuesta { get; set; }
        public Referencia referencia { get; set; }
        public Estado estado { get; set; }
    }
}
