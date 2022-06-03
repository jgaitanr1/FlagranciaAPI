using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apiFlagrancia.Entidades
{
    public class DFlagrancia : IHaveId
    {
        public int Id { get; set; }
        public String Descripcion { get; set; }
        public String Dependencia { get; set; }
        public String FecRegistro { get; set; }
        public String UsuarioRegistro { get; set; }
        public int idFlagrancia { get; set; }
        //Codigo unico de Flagrancia
        [ForeignKey("idFlagrancia")]
        public Flagrancia flagrancia { get; set; }

    }
}
