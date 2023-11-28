using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROYECTO.DataAccess.Context
{
    public class ProductoContext : DbContext
    {
        public DbSet<AutosEntity> Autos { get; set; }
        public DbSet<ClienteEntity> Cliente { get; set; }
        public DbSet<CompraEntity> Compra { get; set; }
        public DbSet<DetalleCompraEntity> Detalle { get; set; }

        public ProductoContext(DbContextOptions<ProductoContext> option) : base(option)
        {

        }
    }
}
