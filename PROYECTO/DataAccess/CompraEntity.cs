using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PROYECTO.DataAccess
{
    [Table("Compra")]
    public class CompraEntity : BaseEntity
    {
 
        public DateTime FechaCompra { get; set; }
        public string NumeroDeTarjeta { get; set; }
        public string Email { get; set; }
        public virtual ClienteEntity Cliente { get; set; }

    }
}
