using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartoothAI.Domain.Entities
{
    [Table("tb_atendimento")]
    public class Atendimento
    {
        [Key]
        [Column("atendimento_id")]
        public int AtendimentoId { get; set; }

        [Column("descricao", TypeName = "VARCHAR2(255)")]
        [Display(Name = "Descrição: ")]
        [StringLength(255, ErrorMessage = "A descrição pode ter no máximo 255 caracteres.")]
        public string Descricao { get; set; }

        [Column("data", TypeName = "DATE")]
        [Display(Name = "Data: ")]
        public DateTime? Data { get; set; }

        [Column("hora", TypeName = "INTERVAL DAY TO SECOND")]
        [Display(Name = "Hora: ")]
        public TimeSpan? Hora { get; set; }

        [Column("incluso_plano", TypeName = "CHAR(1)")]
        [Display(Name = "Incluso no Plano: ")]
        public char? InclusoPlano { get; set; }

        [Column("custo", TypeName = "NUMBER(38, 2)")]
        [Display(Name = "Custo: ")]
        public decimal? Custo { get; set; }

        [Column("profissional_id")]
        [Display(Name = "ID do Profissional: ")]
        [ForeignKey("Profissional")]
        public int ProfissionalId { get; set; }

        [Column("usuario_paciente_id")]
        [Display(Name = "ID do Usuário Paciente: ")]
        [ForeignKey("UsuarioPaciente")]
        public int UsuarioPacienteId { get; set; }

        [Column("recomendacao_trat_id")]
        [Display(Name = "ID da Recomendação de Tratamento: ")]
        [ForeignKey("RecomendacaoTrat")]
        public int RecomendacaoTratId { get; set; }

        public Atendimento()
        { }

        public Atendimento(int atendimentoId, string descricao, DateTime? data, TimeSpan? hora,
                           char? inclusoPlano, decimal? custo, int profissionalId,
                           int usuarioPacienteId, int recomendacaoTratId)
        {
            AtendimentoId = atendimentoId;
            Descricao = descricao;
            Data = data;
            Hora = hora;
            InclusoPlano = inclusoPlano;
            Custo = custo;
            ProfissionalId = profissionalId;
            UsuarioPacienteId = usuarioPacienteId;
            RecomendacaoTratId = recomendacaoTratId;
        }
    }
}
