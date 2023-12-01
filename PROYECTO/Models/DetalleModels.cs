using PROYECTO.DataAccess;

namespace PROYECTO.Models
{
    public class DetalleModels
    {
        public double Precio { get; set; }
        public virtual AutoModels Autos { get; set; }
        public virtual CompraModels Compra { get; set; }

        public bool Status { get; set; }
    }
}
