using apiFlagrancia.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFlagrancia.Utilidades
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
            :base(dbContextOptions)
        {

        }
        public DbSet<Dependencia> Dependencias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Flagrancia> Flagrancias { get; set; }
        public DbSet<DFlagrancia> DFlagrancias { get; set; }
    }
}
