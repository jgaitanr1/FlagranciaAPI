using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFlagrancia.Entidades
{
    public class DFlagrancia
    {
        public int Id { get; set; }
        public String Descripcion { get; set; }
        public String Dependencia { get; set; }
        public DateTime FecRegistro { get; set; }
        public String UsuarioRegistro { get; set; }
        //Codigo unico de Flagrancia
        public Flagrancia flagrancia { get; set; }

    }
}
