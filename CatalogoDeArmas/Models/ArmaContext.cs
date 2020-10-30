using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoDeArmas.Models
{
    public class ArmaContext : DbContext
    {
        public DbSet<Arma> Armas { get; set; }
        public ArmaContext(DbContextOptions<ArmaContext> options) : base(options)
        {

        }
    }
}
