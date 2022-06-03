using apiFlagrancia.DTOs;
using apiFlagrancia.Entidades;
using apiFlagrancia.Utilidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace apiFlagrancia.Controllers
{
    [ApiController]
    [Route("/api/dflagrancia")]
    public class DFlagranciaController : ExtendedBaseController<CreateDFlagranciaDTO, DFlagrancia, DFlagranciaDTO>
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;
        private static readonly Expression<Func<DFlagrancia, DFlagranciaDTO>> AsDFlagranciaDto =
            x => new DFlagranciaDTO
            {
                Id = x.Id,
                Descripcion = x.Descripcion,
                Dependencia = x.Dependencia,
                FecRegistro = x.FecRegistro,
                UsuarioRegistro = x.UsuarioRegistro,
                idFlagrancia =x.flagrancia.Id,
                NombreFlagrante = x.flagrancia.Nombre,
                DocumentoFlagrante = x.flagrancia.Documento
            };
        public DFlagranciaController(ApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper, "DFlagrancia")
        {
            this.applicationDbContext = applicationDbContext;
            this.mapper = mapper;
        }

        [HttpGet("det")]
        public IQueryable<DFlagranciaDTO> GetUsers()
        {
            return applicationDbContext.DFlagrancias.Include(b => b.flagrancia).Select(AsDFlagranciaDto);
        }

        [HttpGet("det/{id}")]
        public IQueryable<DFlagranciaDTO> GetId(int id)
        {
            return applicationDbContext.DFlagrancias.Include(b => b.flagrancia).Select(AsDFlagranciaDto).Where(c => c.idFlagrancia == id);
        }

        //[HttpPost("many")]
        //public virtual async Task<ActionResult> PostManyAsync(List<CreateDFlagranciaDTO> createDTO)
        //{
        //    try
        //    {
        //        var entidad = mapper.Map<List<DFlagrancia>>(createDTO);

        //        applicationDbContext.AddRange(entidad);
        //        await applicationDbContext.SaveChangesAsync();
        //        return new OkResult();
        //    }
        //    catch (Exception)
        //    {
        //        return new BadRequestResult();
        //    }
        //}

    }
}
