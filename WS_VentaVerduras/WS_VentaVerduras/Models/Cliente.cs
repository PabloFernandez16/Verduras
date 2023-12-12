using System;
using System.Collections.Generic;

namespace WS_VentaVerduras.Models
{
    public partial class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Email { get; set; }
    }
}
