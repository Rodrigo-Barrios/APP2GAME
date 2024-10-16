using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using APP2GAME.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using APP2GAME.Models;
using APP2GAME.ViewModel;
using APP2GAME.Helper;

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
            var miscontactos = from o in _context.DataContacto select o;
            _logger.LogDebug("contactos {miscontactos}", miscontactos);
            var ViewModel = new ContactoViewModel{
                FormContacto = new Contacto(),
                ListContacto = miscontactos
            };
            _logger.LogDebug("ViewModel {ViewModel}", ViewModel);
            return View(ViewModel);
        }

    [HttpPost]
    public async Task<IActionResult> Enviar(ContactoViewModel viewModel)
        {
            _logger.LogDebug("Ingreso a Enviar Mensaje");
            
            var contacto = new Contacto
            {
                Name = viewModel.FormContacto.Name,
                Email = viewModel.FormContacto.Email,
                Message = viewModel.FormContacto.Message,
                Contrasena = viewModel.FormContacto.Contrasena
            };

            //var emailService = new SendMail();
            //await emailService.EnviarCorreoAsync(contacto.Email, "Asunto del correo", contacto.Message,contacto.Contrasena);
            var __apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");

            var emailService2 = new SendMailSendGrid();
            await emailService2.EnviarCorreoAsync(contacto.Email, "Asunto del correo", contacto.Message,contacto.Contrasena);
            
            
            _context.Add(contacto);
            _context.SaveChanges();

            ViewData["Message"] = "Se registro el contacto";

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}