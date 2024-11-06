using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartoothAI.Domain.Entities
{
    [Table("tb_profissional")]
    public class Profissional
    {
        [Key]
        [Column("profissional_id")]
        public int ProfissionalId { get; set; }

        [Column("nome")]
        [Display(Name = "Nome:")]
        [StringLength(100)] 
        public string Nome { get; set; }

        [Column("especialidade")]
        [Display(Name = "Especialidade:")]
        [StringLength(85)] 
        public string Especialidade { get; set; }

        [Column("experiencia")]
        [Display(Name = "Experiência:")]
        [StringLength(150)] 
        public string Experiencia { get; set; }

        [Column("contato")]
        [Display(Name = "Contato:")]
        [StringLength(45)]
        public string Contato { get; set; }

        public Profissional()
        { }

        public Profissional(int profissionalId, string nome, string especialidade, string experiencia, string contato)
        {
            ProfissionalId = profissionalId;
            Nome = nome;
            Especialidade = especialidade;
            Experiencia = experiencia;
            Contato = contato;
        }
    }
}
