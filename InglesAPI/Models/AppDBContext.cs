using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InglesModels;
using Microsoft.EntityFrameworkCore;

namespace InglesAPI.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Capitulo> Capitulos { get; set; }
        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<Questao> Questoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }



}
