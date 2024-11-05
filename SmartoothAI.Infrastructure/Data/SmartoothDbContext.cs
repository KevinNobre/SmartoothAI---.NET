using Microsoft.EntityFrameworkCore;
using SmartoothAI.Domain.Entities;

namespace SmartoothAI.Infrastructure.Data
{
    public class SmartoothDbContext : DbContext
    {
        public SmartoothDbContext(DbContextOptions<SmartoothDbContext> options) : base(options)
        {
        }

        public DbSet<Atendimento> Atendimentos { get; set; }

        public DbSet<Dica> Dicas { get; set; }

        public DbSet<Plano> Planos { get; set; }

        public DbSet<Procedimento> Procedimentos { get; set; }

        public DbSet<Prontuario> Prontuarios { get; set; }

        public DbSet<RecomendacaoTrat> RecomendacoesTrat { get; set; }

        public DbSet<SistemaPontos> SistemaPontos { get; set; }

        public DbSet<UsuarioPaciente> UsuariosPacientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
