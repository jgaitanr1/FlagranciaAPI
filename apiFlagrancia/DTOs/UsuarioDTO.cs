using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFlagrancia.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public String Nombres { get; set; }
        public String Apellidos { get; set; }
        public String DNI { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public Boolean Estado { get; set; }
        //dependencia
        public String depNombre { get; set; }
        public int dependencia { get; set; }
    }
}
