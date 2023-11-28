using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROYECTO.Models
{
    public class AutoModels
    {
        public string Codigo { get; set; }
        public string Numero_Serie { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
        public bool? EnvioDomicilio { get; set; }
        public bool? RetiroEnTienda { get; set; }
        public string Imagen { get; set; }
        public string Descripcion { get; set; }
    }
}
