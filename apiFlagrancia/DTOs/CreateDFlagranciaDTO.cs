using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFlagrancia.DTOs
{
    public class CreateDFlagranciaDTO
    {
        public String Descripcion { get; set; }
        public String Dependencia { get; set; }
        public DateTime FecRegistro { get; set; }
        public String UsuarioRegistro { get; set; }
        //Codigo unico de Flagrancia
        public int flagrancia { get; set; }
    }
}
