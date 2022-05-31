using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiFlagrancia.DTOs
{
    public class CreateUsuarioDTO
    {
        [Required]
        public String Nombres { get; set; }
        [Required]
        public String Apellidos { get; set; }
        [Required]
        public String DNI { get; set; }
        [Required]
        public String Username { get; set; }
        [Required]
        public String Password { get; set; }
        [Required]
        public Boolean Estado { get; set; }

        //dependencia
        [Required]
        public int dependencia { get; set; }
    }
}
