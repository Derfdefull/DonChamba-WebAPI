using System;
using System.Collections.Generic;

namespace WebAPIDonChamba.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            
        }

        public int PkIdUsuario { get; set; }
        public int FkIdSucursal { get; set; }
        public string Usuario1 { get; set; } = null!;
        public string Contrasena { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string? Celular { get; set; }
        public string? Telefono { get; set; }
         
    }
}
