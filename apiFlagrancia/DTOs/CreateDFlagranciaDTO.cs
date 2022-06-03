using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiFlagrancia.DTOs
{
    public class CreateDFlagranciaDTO
    {
        [Required]
        public String Descripcion { get; set; }
        public String Dependencia { get; set; }
        public String FecRegistro { get; set; }
        public String UsuarioRegistro { get; set; }
        //Codigo unico de Flagrancia
        public int idFlagrancia { get; set; }
    }
}
