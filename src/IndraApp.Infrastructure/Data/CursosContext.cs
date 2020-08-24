using IndraApp.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndraApp.Infrastructure.Data
{
    public class CursosContext : DbContext
    {
        // Construtor
        public CursosContext(DbContextOptions<CursosContext> options) : base(options)
        {
            
        }

        #region Defindo os DbSet das Entities
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Estudante> Estudantes { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Pagamento> CuPagamentos { get; set; }
        public DbSet<Cartao> Cartoes { get; set; }
        #endregion

        // Configurações da base feitas por Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Adicionandos primeiros registros na criação do banco de dados
            modelBuilder.Seed();
        }

    }
}
