using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartoothAI.Domain.Entities
{
    [Table("tb_sistema_pontos")]
    public class SistemaPontos
    {
        [Key]
        [Column("pontos_id")]
        public int PontosId { get; set; }

        [Column("total_pontos")]
        public decimal? TotalPontos { get; set; }

        [Column("tipo_pontos")]
        [MaxLength(155)]
        public string TipoPontos { get; set; }

        [Column("plano_id")]
        [ForeignKey("PlanoId")]
        public int PlanoId { get; set; }

        public SistemaPontos()
        { }

        public SistemaPontos(int pontosId, decimal? totalPontos, string tipoPontos, int planoId)
        {
            PontosId = pontosId;
            TotalPontos = totalPontos;
            TipoPontos = tipoPontos;
            PlanoId = planoId;
        }
    }
}
