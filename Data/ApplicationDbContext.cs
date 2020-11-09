using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using projeto.Models;

namespace projeto.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Funcionario> funcionarios { get; set; }
        public DbSet<Gft> gfts { get; set; }
        public DbSet<Tecnologia> tecnologias { get; set; }
        public DbSet<Vaga> vagas { get; set; }
        public DbSet<FuncionarioTecnologia> funcionariostecnologias { get; set; }
        public DbSet<VagaTecnologia> vagastecnologias { get; set; }
        public DbSet<Popular> popular { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FuncionarioTecnologia>().HasKey(sc => new { sc.FuncionarioID, sc.TecnologiaID });
            modelBuilder.Entity<VagaTecnologia>().HasKey(sc => new { sc.VagaID, sc.TecnologiaID });
            base.OnModelCreating(modelBuilder); // NÃO REMOVA ESSA LINHA
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
