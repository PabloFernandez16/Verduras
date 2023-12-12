using System;
using System.Collections.Generic;

namespace WS_VentaVerduras.Models
{
    public partial class Venta
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal? Total { get; set; }
    }
}
