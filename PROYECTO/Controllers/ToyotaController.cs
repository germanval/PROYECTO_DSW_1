using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROYECTO.DataAccess.Context;
using PROYECTO.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PROYECTO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
  
       
    }

}
