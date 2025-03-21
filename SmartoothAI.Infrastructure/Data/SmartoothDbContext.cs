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
            modelBuilder.Entity<Atendimento>().ToTable("tb_atendimento");
            modelBuilder.Entity<Dica>().ToTable("tb_dica");
            modelBuilder.Entity<Plano>().ToTable("tb_plano");
            modelBuilder.Entity<Procedimento>().ToTable("tb_procedimento");
            modelBuilder.Entity<Prontuario>().ToTable("tb_prontuario");
            modelBuilder.Entity<RecomendacaoTrat>().ToTable("tb_recomendacao_trat");
            modelBuilder.Entity<SistemaPontos>().ToTable("tb_sistema_pontos");
            modelBuilder.Entity<UsuarioPaciente>().ToTable("tb_usuario_paciente");
            modelBuilder.Entity<RecomendacaoTrat>()
                .HasNoKey();  
    
            // modelBuilder.Entity<AlgumaEntidade>()
            //     .HasKey(e => new { e.Chave1, e.Chave2 });

            base.OnModelCreating(modelBuilder);
        }
    }
}
