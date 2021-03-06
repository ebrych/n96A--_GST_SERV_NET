﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beans
{
    public class Proveedor
    {
        public long idProveedor { get; set; }
        public string nombres { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public Tipo tipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public string mail { get; set; }
        public string fechaRegistro { get; set; }
        public string fechaModificacion { get; set; }
        public Estado estado { get; set; }
    }
}
