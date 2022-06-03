using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFlagrancia.DTOs
{
    public class DFlagranciaDTO
    {
        public int Id { get; set; }
        public String Descripcion { get; set; }
        public String Dependencia { get; set; }
        public String FecRegistro { get; set; }
        public String UsuarioRegistro { get; set; }
        //Codigo unico de Flagrancia
        public int idFlagrancia { get; set; }
        public String NombreFlagrante { get; set; }
        public String DocumentoFlagrante { get; set; }
    }
}
