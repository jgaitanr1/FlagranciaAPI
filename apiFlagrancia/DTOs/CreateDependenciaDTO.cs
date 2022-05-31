using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiFlagrancia.DTOs
{
    public class CreateDependenciaDTO
    {
        [Required]
        public String Nombre { get; set; }
    }
}
