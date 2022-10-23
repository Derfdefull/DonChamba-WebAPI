using System;
using System.Collections.Generic;

namespace WebAPIDonChamba.Models
{
    public partial class Sucursale
    {
        public Sucursale()
        {
             
        }

        public int PkIdSucursal { get; set; }
        public string Nombre { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
         
    }
}
