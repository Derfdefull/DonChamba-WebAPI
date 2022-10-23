using System;
using System.Collections.Generic;

namespace WebAPIDonChamba.Models
{
    public partial class Producto
    {
        public Producto()
        {
            
        }

        public int PkIdProducto { get; set; }
        public int FkIdCategoria { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public byte Estado { get; set; }
        public string Imagen { get; set; } = null!;
        public decimal Precio { get; set; }  

    }
}
