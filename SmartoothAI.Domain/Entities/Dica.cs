using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartoothAI.Domain.Entities
{
    [Table("tb_dicas")]
    public class Dica
    {
        [Key]
        [Column("dica_id")]
        public int DicaId { get; set; }

        [Column("descricao")]
        [Display(Name = "Descrição:")]
        [StringLength(255)] 
        public string Descricao { get; set; }

        [Column("prontuario_prontuario_id")]
        public int ProntuarioId { get; set; }

        [Column("usuario_paciente_paciente_id")]
        public int UsuarioPacienteId { get; set; }

        public Dica()
        { }

        public Dica(int dicaId, string descricao, int prontuarioProntuarioId, int usuarioPacienteId)
        {
            DicaId = dicaId;
            Descricao = descricao;
            ProntuarioId = prontuarioProntuarioId;
            UsuarioPacienteId = usuarioPacienteId;
        }
    }
}
