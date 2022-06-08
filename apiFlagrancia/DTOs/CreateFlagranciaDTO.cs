using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiFlagrancia.DTOs
{
    public class CreateFlagranciaDTO
    {
        [Required]
        public String Nombre { get; set; }
        public String Documento { get; set; }
        public String SituacionJuridica { get; set; }
        public String Sentencia { get; set; }
        public String Descripcion { get; set; }
        public String Latitud { get; set; }
        public String Longitud { get; set; }
        public String tipoArresto { get; set; }
        [Required]
        public String UsuarioRegistro { get; set; }
        [Required]
        public String FecRegistro { get; set; }
        [Required]
        public String EstadoFlagrante { get; set; }
        public Boolean Estado { get; set; }
    }
}
