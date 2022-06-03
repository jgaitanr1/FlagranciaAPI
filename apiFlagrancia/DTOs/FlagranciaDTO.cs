using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFlagrancia.DTOs
{
    public class FlagranciaDTO
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Documento { get; set; }
        public String SituacionJuridica { get; set; }
        public String Sentencia { get; set; }
        public String Latitud { get; set; }
        public String Longitud { get; set; }
        public String UsuarioRegistro { get; set; }
        public String FecRegistro { get; set; }
        public String EstadoFlagrante { get; set; }
        public Boolean Estado { get; set; }
    }
}
