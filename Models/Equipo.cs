using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace nextapp.Models
{
    public class Equipo
    {
        [Display(Name = "ID")]
        public int id_equipos { get; set; }

        [Display(Name = "Marca")]
        public string marca { get; set; }

        [Display(Name = "Modelo")]
        public string modelo { get; set; }

        [Display(Name = "Serie")]
        public string serie { get; set; }

        [Display(Name = "Caracteristicas")]
        public string caracteristicas { get; set; }

        [Display(Name = "Equipo")]
        public string tipo_equipo { get; set; }

        [Display(Name ="Stock")]
        public string stock { get; set; }

       
        [Display(Name ="Fecha Registro")]
        public string fecha_registro { get; set; }
        

    }
}
