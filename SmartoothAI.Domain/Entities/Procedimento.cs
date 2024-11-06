using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartoothAI.Domain.Entities
{
    [Table("tb_procedimento")]
    public class Procedimento
    {
        [Key]
        [Column("procedimento_id")]
        public int ProcedimentoId { get; set; }

        [Column("nome_procedimento")]
        [Display(Name = "Nome do Procedimento:")]
        [StringLength(85)] 
        public string NomeProcedimento { get; set; }

        [Column("descricao")]
        [Display(Name = "Descrição:")]
        [StringLength(255)]
        public string Descricao { get; set; }

        [Column("incluso_plano")]
        [Display(Name = "Incluso no Plano:")]
        public char? InclusaoPlano { get; set; }

        [Column("prontuario_id")]
        public int ProntuarioId { get; set; }

        [Column("sistema_pontos_id")]
        public int SistemaPontosId { get; set; }

        [Column("usuario_paciente_paciente_id")]
        public int UsPacienteId { get; set; }

        public Procedimento()
        { }

        public Procedimento(int procedimentoId, string nomeProcedimento, string descricao,
                            char? inclusaoPlano, int prontuarioId, int sistemaPontosId, int usPacienteId)
        {
            ProcedimentoId = procedimentoId;
            NomeProcedimento = nomeProcedimento;
            Descricao = descricao;
            InclusaoPlano = inclusaoPlano;
            ProntuarioId = prontuarioId;
            SistemaPontosId = sistemaPontosId;
            UsPacienteId = usPacienteId;
        }
    }
}
