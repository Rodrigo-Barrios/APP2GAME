using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using APP2GAME.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using APP2GAME.Models;

namespace APP2GAME.Controllers
{
    public class ContactoController : Controller
    {
        private readonly ILogger<ContactoController> _logger;
        private readonly ApplicationDbContext _context;

        public ContactoController(ILogger<ContactoController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

    [HttpPost]
    public IActionResult Enviar(Contacto objcontato)
        {
            _logger.LogDebug("Ingreso a Enviar Mensaje");
            
            _context.Add(objcontato);
            _context.SaveChanges();

            ViewData["Message"] = "Se registro el contacto";

            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}