using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROYECTO.DataAccess.Context;
using PROYECTO.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PROYECTO.Controllers
{
    [ApiController]
    [Route("api/toyota")]
    public class ToyotaController : ControllerBase
    {
        private readonly ProductoContext _productoContext;
        private readonly IMapper _mapper;
    
        public ToyotaController(ProductoContext productoContext,IMapper mapper,IWebHostEnvironment webHostEnvironment)
        {
            _productoContext = productoContext;
            _mapper = mapper;
         
        }

        [HttpGet]
        [Route("")]
        public IList<AutoModels> GetAll()
        {
            var listar = _productoContext.Autos.ToList();
            var contenido = _mapper.Map<List<AutoModels>>(listar);
            return contenido;
        }



        [HttpGet("ListadoDeDetalles")]
        public IList<DetalleModels> GetDetallesConAutos()
        {
            var detallesConAutos = _productoContext.Detalle
                .Include(d => d.Autos)
                .Include(d => d.Compra)
                    .ThenInclude(c => c.Cliente)
                .ToList();

            if (detallesConAutos == null || detallesConAutos.Count == 0)
            {
                return new List<DetalleModels>(); // O retorna null según tus requisitos
            }

            // Mapeo manual para seleccionar las propiedades específicas
            var detallesModels = detallesConAutos.Select(d => new DetalleModels
            {
                Precio = d.Precio,
                Autos = d.Autos != null ? new AutoModels
                {
                    Codigo = d.Autos.Codigo,
                    Numero_Serie = d.Autos.Numero_Serie,
                    Nombre = d.Autos.Nombre,
                    Precio = d.Autos.Precio,
                    Stock = d.Autos.Stock,
                    EnvioDomicilio = d.Autos.EnvioDomicilio,
                    RetiroEnTienda = d.Autos.RetiroEnTienda,
                    Imagen = $"../Imagenes/Autos/{d.Autos.Imagen}",
                    Descripcion = d.Autos.Descripcion
                } : null,
                Compra = d.Compra != null ? new CompraModels
                {
                    FechaCompra = d.Compra.FechaCompra,
                    NumeroDeTarjeta = d.Compra.NumeroDeTarjeta,
                    Email = d.Compra.Email,
                    Cliente = d.Compra.Cliente != null ? new ClienteModels
                    {
                       
                        Nombres = d.Compra.Cliente.Nombres,
                        Apellidos = d.Compra.Cliente.Apellidos,
                        Dni = d.Compra.Cliente.Dni,
                        Usuario = d.Compra.Cliente.Usuario,
                        Password = d.Compra.Cliente.Password,
                        Status = d.Compra.Cliente.Status
                    } : null
                } : null,
                Status = d.Status
            }).ToList();

            return detallesModels;
        }

    }

}
