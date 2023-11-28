using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PROYECTO.DataAccess
{
    [Table("Cliente")]
    public class ClienteEntity : BaseEntity
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Dni { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
    }
}
