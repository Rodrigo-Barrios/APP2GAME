using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APP2GAME.Models;

namespace APP2GAME.ViewModel
{
    public class ContactoViewModel
    {
        public Contacto? FormContacto { get; set; }
        public IEnumerable<Contacto>? ListContacto { get; set; }

    }
}