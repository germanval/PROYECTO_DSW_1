using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PROYECTO.DataAccess
{
    [Table("Detalle")]
    public class DetalleCompraEntity :BaseEntity
    {
       
        public double Precio { get; set; }
        public virtual AutosEntity Autos { get; set; }
        public virtual CompraEntity Compra { get; set; }
    }
}
