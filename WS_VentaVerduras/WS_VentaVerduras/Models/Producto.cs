using System;
using System.Collections.Generic;

namespace WS_VentaVerduras.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetalleVenta = new HashSet<DetalleVenta>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal PrecioUnitario { get; set; }
        public decimal? Costo { get; set; }

        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}
