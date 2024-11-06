using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartoothAI.Domain.Entities
{
    [Table("tb_recomendacao_trat")]
    public class RecomendacaoTrat
    {
        [Key]
        [Column("recomendacao_id")]
        public int RecomendacaoId { get; set; }

        [Column("data_rec")]
        [Display(Name = "Data de Recomendação:")]
        public DateTime? DataRec { get; set; }

        [Column("plano_id")]
        [ForeignKey("PlanoId")]
        public int PlanoId { get; set; }

        public RecomendacaoTrat()
        { }

        public RecomendacaoTrat(int recomendacaoId, DateTime? dataRec, int planoId)
        {
            this.RecomendacaoId = recomendacaoId;
            DataRec = dataRec;
            PlanoId = planoId;
        }
    }
}
