using apiFlagrancia.DTOs;
using apiFlagrancia.Entidades;
using apiFlagrancia.Utilidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFlagrancia.Controllers
{
    [ApiController]
    [Route("/api/dependencia")]
    public class DependenciaController : ExtendedBaseController<CreateDependenciaDTO, Dependencia, DependenciaDTO>
    {
        public DependenciaController(ApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext,mapper,"Dependencia")
        {

        }
    }
}
