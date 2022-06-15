using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace nextapp.Models
{
    public class Solicitud
    {
       
        [Display(Name = "ID")]
        public int id_Solicitud { get; set; }

        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Display(Name = "Apellido")]
        public string apellido { get; set; }

        [Display(Name = "Codigo")]
        public string codigo_empleado { get; set; }

        [Display(Name = "correo")]
        public string correo { get; set; }

        [Display(Name = "Telefono")]
        public string telefono { get; set; }

        [Display(Name = "Cargo")]
        public string cargo { get; set; }

        [Display(Name = "Tipo Solitud")]
        public string tipo_solicitud { get; set; }

        [Display(Name = "Tecnico Asignado")]
        public string tecnico_asignado { get; set; }

        [Display(Name = "Fecha de solicitud")]
        public string fecha_solicitud { get; set; }

        [Display(Name = "Mensaje")]
        public string mensaje { get; set; }

    }
}
