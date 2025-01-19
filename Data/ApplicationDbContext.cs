using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaAlmacenamiento.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaAlmacenamiento.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<SistemaAlmacenamiento.Models.Cliente> Clientes { get; set; }
    }
}