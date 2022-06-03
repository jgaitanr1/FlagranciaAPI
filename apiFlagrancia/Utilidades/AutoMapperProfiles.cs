using apiFlagrancia.DTOs;
using apiFlagrancia.Entidades;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFlagrancia.Utilidades
{
    public class AutoMapperProfiles :Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Dependencia, DependenciaDTO>()
                .ReverseMap();
            CreateMap<CreateDependenciaDTO, Dependencia>();

            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(p => p.dependencia, options => options.Ignore())
                .ForMember(p => p.depNombre, options => options.Ignore())
                .ReverseMap();
            CreateMap<CreateUsuarioDTO, Usuario>();

            CreateMap<Flagrancia, FlagranciaDTO>()
                .ReverseMap();
            CreateMap<CreateFlagranciaDTO, Flagrancia>();

            CreateMap<DFlagrancia, DFlagranciaDTO>()
                .ForMember(p => p.NombreFlagrante, options => options.Ignore())
                .ForMember(p => p.DocumentoFlagrante, options => options.Ignore())
                .ReverseMap();
            CreateMap<CreateDFlagranciaDTO, DFlagrancia>();
        }
    }
}
