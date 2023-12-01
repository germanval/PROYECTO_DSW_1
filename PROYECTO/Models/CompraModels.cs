using PROYECTO.DataAccess;
using System;

namespace PROYECTO.Models
{
    public class CompraModels
    {
        public DateTime FechaCompra { get; set; }
        public string NumeroDeTarjeta { get; set; }
        public string Email { get; set; }
        public virtual ClienteModels Cliente { get; set; }

        public bool Status { get; set; }
    }
}
