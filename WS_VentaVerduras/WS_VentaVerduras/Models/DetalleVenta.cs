using System;
using System.Collections.Generic;

namespace WS_VentaVerduras.Models
{
    public partial class DetalleVenta
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal? SubTotal { get; set; }
        public int IdProducto { get; set; }

        public virtual Producto IdProductoNavigation { get; set; } = null!;
    }
}
