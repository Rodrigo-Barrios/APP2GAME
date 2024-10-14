using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using APP2GAME.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APP2GAME.Controllers.Rest
{

    [ApiController]
    [Route("api/producto")]
    public class ProductoRest : ControllerBase
    {
        private readonly ILogger<ProductoRest> _logger;
        
        public ProductoRest(ILogger<ProductoRest> logger)
        {
            _logger = logger;
        }
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Producto>>> GetProductos(){
            var productos = new List<Producto>();
            Producto producto = new Producto();
            producto.Id = 1;
            producto.Nombre = "Super Mario Bros";
            producto.Descripcion = "Juego de aventuras";
            producto.Precio = 100;
            productos.Add(producto);
            _logger.LogInformation("GetProductos{0}", productos);
            return Ok(productos);
        }
  
    }
}