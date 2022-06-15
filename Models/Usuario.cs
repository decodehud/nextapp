using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nextapp.Models
{
    public class Usuario
    {
        public string nombre { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }

        public string[] Roles { get; set; }

    }
}
