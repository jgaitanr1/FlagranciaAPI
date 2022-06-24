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
    public class ExtendedBaseController<TCreation, TEntity, TDTO> : Controller
        where TEntity:class, IHaveId
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;
        private readonly String controllerName;
        public ExtendedBaseController(ApplicationDbContext applicationDbContext, IMapper mapper, string controllerName)
        {
            this.applicationDbContext = applicationDbContext;
            this.mapper = mapper;
            this.controllerName = controllerName;
        }

        [HttpGet]
        public async Task<ActionResult<List<TDTO>>> Get()
        {
            var entidad = await applicationDbContext.Set<TEntity>().ToListAsync();
            if (entidad == null)
            {
                return NotFound();
            }
            return mapper.Map<List<TDTO>>(entidad);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TDTO>> Get(int id)
        {
            var entidad = await applicationDbContext.Set<TEntity>().FirstOrDefaultAsync(c => c.Id == id);
            if (entidad == null)
            {
                return NotFound();
            }
            return mapper.Map<TDTO>(entidad);
        }

        [HttpPost]
        public async Task<ActionResult> Post(TCreation creationDTO)
        {
            var entidad = mapper.Map<TEntity>(creationDTO);

            applicationDbContext.Add(entidad);
            await applicationDbContext.SaveChangesAsync();
            var dto = mapper.Map<TDTO>(entidad);
            return new CreatedAtActionResult(nameof(Get), controllerName, new { id = entidad.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, TCreation creationDTO)
        {
            var entidad = await applicationDbContext.Set<TEntity>().FirstOrDefaultAsync(c => c.Id == id);
            if (entidad == null)
            {
                return NotFound();
            }
            mapper.Map(creationDTO, entidad);
            applicationDbContext.Entry(entidad).State = EntityState.Modified;
            await applicationDbContext.SaveChangesAsync();
            return NoContent();
        }

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    var entidad = await applicationDbContext.Set<TEntity>().FirstOrDefaultAsync(c => c.Id == id);
        //    if (entidad == null)
        //    {
        //        return NotFound();
        //    }
        //    applicationDbContext.Entry(entidad).State = EntityState.Deleted;
        //    await applicationDbContext.SaveChangesAsync();
        //    return NoContent();
        //}

    }
}
