using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartoothAI.Domain.Entities
{
    [Table("tb_prontuario")]
    public class Prontuario
    {
        [Key]
        [Column("prontuario_id")]
        public int ProntuarioId { get; set; }

        [Column("prescricao")]
        [StringLength(255)] 
        [Display(Name = "Prescrição:")]
        public string Prescricao { get; set; }

        [Column("observacoes")]
        [StringLength(255)] 
        [Display(Name = "Observações:")]
        public string Observacoes { get; set; }

        [Column("data_registro")]
        [Display(Name = "Data de Registro:")]
        public DateTime? DataRegistro { get; set; }

        public Prontuario()
        { }

        public Prontuario(int prontuarioId, string prescricao, string observacoes, DateTime? dataRegistro)
        {
            ProntuarioId = prontuarioId;
            Prescricao = prescricao;
            Observacoes = observacoes;
            DataRegistro = dataRegistro;
        }
    }
}

