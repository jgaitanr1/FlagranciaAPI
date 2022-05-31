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
    [Route("/api/usuario")]
    public class UsuarioController : ExtendedBaseController<CreateUsuarioDTO, Usuario, UsuarioDTO>
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;
        private static readonly Expression<Func<Usuario, UsuarioDTO>> AsUsuarioDto =
            x => new UsuarioDTO
            {
                Id = x.Id,
                Nombres = x.Nombres,
                Apellidos = x.Apellidos,
                DNI = x.DNI,
                Username = x.Username,
                Password = x.Password,
                Estado = x.Estado,
                dependencia = x.dependencia.Id,
                depNombre = x.dependencia.Nombre
            };
        public UsuarioController(ApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper, "Usuario")
        {
            this.applicationDbContext = applicationDbContext;
            this.mapper = mapper;
        }

        //return applicationDbContext.Pedidos.Include(b => b.cliente).Select(AsEntityDto).Where(x => x.EstadoPedido.Equals("Listo") || x.EstadoPedido.Equals("Enviado"));

        [HttpGet("{username}/{password}")]
        public ActionResult<List<UsuarioDTO>> GetIniciarSesion(String username, String password)
        {
            var usuario = applicationDbContext.Usuarios.Where(u => u.Username.Equals(username) && u.Password.Equals(password) && u.Estado.Equals(true)).Select(AsUsuarioDto);
            if (usuario == null)
            {
                return NotFound();
            }
            return mapper.Map<List<UsuarioDTO>>(usuario);
        }
    }
}
