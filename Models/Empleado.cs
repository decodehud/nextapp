using System.ComponentModel.DataAnnotations;

namespace nextapp.Models
{
    public class Empleado
    {

        [Display(Name = "ID")]
        public int id_empleados { get; set; }

        [Required(ErrorMessage = "Ingrese su nombre")]
        [Display(Name = "Firt Name")]
        public string nombre { get; set; }

        [Display(Name = "Last Name")]
        public string apellido { get; set; }

        [Display(Name = "Code")]
        public string codigo_empleado { get; set; }

        [Display(Name = "Cargo")]
        public string cargo { get; set; }

        [Display(Name = "Correo")]
        public string correo { get; set; }

        [Display(Name = "Area")]
        public string departamento { get; set; }

        [Display(Name = "Asignado")]
        public string equipo_asignado { get; set; }

        [Display(Name = "Fecha Asignacion")]
        public string fecha_asignacion { get; set; }


    }
}
