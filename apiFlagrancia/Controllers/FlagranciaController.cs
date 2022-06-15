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
    [Route("/api/flagrancia")]
    public class FlagranciaController : ExtendedBaseController<CreateFlagranciaDTO, Flagrancia, FlagranciaDTO>
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;
        private static readonly Expression<Func<Flagrancia, FlagranciaDTO>> AsFlagranciaDto =
            x => new FlagranciaDTO
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Documento = x.Documento,
                SituacionJuridica = x.SituacionJuridica,
                Sentencia = x.Sentencia,
                Audiencia = x.Audiencia,
                Acusacion = x.Acusacion,
                Descripcion = x.Descripcion,
                Latitud = x.Latitud,
                Longitud = x.Longitud,
                tipoArresto = x.tipoArresto,
                UsuarioRegistro = x.UsuarioRegistro,
                FecRegistro = x.FecRegistro,
                EstadoFlagrante = x.EstadoFlagrante,
                Estado = x.Estado
            };
        public FlagranciaController(ApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper, "Flagrancia")
        {
            this.applicationDbContext = applicationDbContext;
            this.mapper = mapper;
        }

        [HttpGet("detenido")]
        public ActionResult<List<FlagranciaDTO>> GetRegistrado()
        {
            var entity = applicationDbContext.Flagrancias.Where(u => u.EstadoFlagrante.Equals("Detenido")).Select(AsFlagranciaDto);
            if (entity == null)
            {
                return NotFound();
            }
            return mapper.Map<List<FlagranciaDTO>>(entity);
        }

        

        [HttpPut("{id}/ingresado")]
        public ActionResult PutEstadoFlagrante(int id, CreateFlagranciaDTO createDTO)
        {
            var entidad = applicationDbContext.Set<Flagrancia>().FirstOrDefault(c => c.Id == id);
            if (entidad == null)
            {
                return NotFound();
            }
            mapper.Map(createDTO, entidad);
            //entidad.FecRegistro = ""+DateTime.Now.ToLocalTime();
            entidad.EstadoFlagrante = "Ingresado";

            applicationDbContext.Entry(entidad).State = EntityState.Modified;
            applicationDbContext.SaveChanges();
            return NoContent();
        }

        [HttpGet("ingresado")]
        public ActionResult<List<FlagranciaDTO>> GetIngresado()
        {
            var entity = applicationDbContext.Flagrancias.Where(u => u.EstadoFlagrante.Equals("Ingresado")).Select(AsFlagranciaDto);
            if (entity == null)
            {
                return NotFound();
            }
            return mapper.Map<List<FlagranciaDTO>>(entity);
        }

        //[HttpGet("mp")]
        //public ActionResult<List<FlagranciaDTO>> GetMP()
        //{
        //    // var entity = applicationDbContext.Flagrancias.Where(u => !u.EstadoFlagrante.Equals("Resuelto") || !u.EstadoFlagrante.Equals("Poder Judicial")).Select(AsFlagranciaDto);
        //    var entity = applicationDbContext.Flagrancias.Where(u => !u.EstadoFlagrante.Equals("Poder Judicial")).Where(u => !u.EstadoFlagrante.Equals("Resuelto")).Select(AsFlagranciaDto);
        //    if (entity == null)
        //    {
        //        return NotFound();
        //    }
        //    return mapper.Map<List<FlagranciaDTO>>(entity);
        //}
        [HttpGet("pnp")]
        public ActionResult<List<FlagranciaDTO>> GetPNP()
        {
            var entity = applicationDbContext.Flagrancias.Where(u => u.EstadoFlagrante == "Detenido" || u.EstadoFlagrante == "Ingresado").Select(AsFlagranciaDto);
            if (entity == null)
            {
                return NotFound();
            } 
            return mapper.Map<List<FlagranciaDTO>>(entity);
        }

        [HttpGet("mp")]
        public ActionResult<List<FlagranciaDTO>> GetMP()
        {
            var entity = applicationDbContext.Flagrancias.Where(u => u.EstadoFlagrante == ("Identificado") || u.EstadoFlagrante == ("Audiencia")).Select(AsFlagranciaDto);
            if (entity == null)
            {
                return NotFound();
            }
            return mapper.Map<List<FlagranciaDTO>>(entity);
        }

        [HttpGet("pj")]
        public ActionResult<List<FlagranciaDTO>> GetPJ()
        {
            var entity = applicationDbContext.Flagrancias.Where(u => u.EstadoFlagrante.Equals("Poder Judicial") || u.EstadoFlagrante == ("Audiencia")).Select(AsFlagranciaDto);
            if (entity == null)
            {
                return NotFound();
            }
            return mapper.Map<List<FlagranciaDTO>>(entity);
        }
    }
}
