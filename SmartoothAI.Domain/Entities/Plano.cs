using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartoothAI.Domain.Entities
{
    [Table("tb_plano")]
    public class Plano
    {
        [Key]
        [Column("plano_id")]
        public int PlanoId { get; set; }

        [Column("tipo_plano")]
        [Display(Name = "Tipo do Plano:")]
        [StringLength(55)]
        public string TipoPlano { get; set; }

        [Column("descricao")]
        [Display(Name = "Descrição:")]
        [StringLength(255)] 
        public string Descricao { get; set; }

        [Column("marca_plano")]
        [Display(Name = "Marca do Plano:")]
        [StringLength(110)] 
        public string MarcaPlano { get; set; }

        [Column("tipo_pagamento")]
        [Display(Name = "Tipo de Pagamento:")]
        [StringLength(85)] 
        public string TipoPagamento { get; set; }

        [Column("usuario_paciente_id")]
        public int UsuarioPacienteId { get; set; }

        public Plano()
        { }

        public Plano(int planoId, string tipoPlano, string descricao,
                     string marcaPlano, string tipoPagamento, int usuarioPacienteId)
        {
            PlanoId = planoId;
            TipoPlano = tipoPlano;
            Descricao = descricao;
            MarcaPlano = marcaPlano;
            TipoPagamento = tipoPagamento;
            UsuarioPacienteId = usuarioPacienteId;
        }
    }
}
