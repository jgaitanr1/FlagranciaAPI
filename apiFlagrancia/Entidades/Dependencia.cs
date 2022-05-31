using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFlagrancia.Entidades
{
    public class Dependencia : IHaveId
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
    }
}
