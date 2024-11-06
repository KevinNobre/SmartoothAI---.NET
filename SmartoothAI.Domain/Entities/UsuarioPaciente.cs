using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartoothAI.Domain.Entities
{
    [Table("tb_usuario_paciente")]
    public class UsuarioPaciente
    {
        [Key]
        [Column("paciente_id")]
        public int PacienteId { get; set; }

        [Column("nome")]
        [MaxLength(55)]
        public string Nome { get; set; }

        [Column("sobrenome")]
        [MaxLength(55)]
        public string Sobrenome { get; set; }

        [Column("email")]
        [MaxLength(105)]
        public string Email { get; set; }

        [Column("data_nasc")]
        public DateTime? DataNasc { get; set; }

        [Column("genero")]
        [MaxLength(35)]
        public string Genero { get; set; }

        [Column("cep")]
        [MaxLength(12)]
        public string Cep { get; set; }

        [Column("logradouro")]
        [MaxLength(105)]
        public string Logradouro { get; set; }

        [Column("numero")]
        [MaxLength(8)]
        public string Numero { get; set; }

        [Column("complemento")]
        [MaxLength(105)]
        public string Complemento { get; set; }

        [Column("bairro")]
        [MaxLength(85)]
        public string Bairro { get; set; }

        [Column("cidade")]
        [MaxLength(55)]
        public string Cidade { get; set; }

        [Column("uf")]
        [MaxLength(2)]
        public string Uf { get; set; }

        [Column("contato")]
        [MaxLength(35)]
        public string Contato { get; set; }

        [Column("pontos")]
        public decimal? Pontos { get; set; }

        [Column("descontos")]
        public decimal? Descontos { get; set; }

        public UsuarioPaciente()
        { }

        public UsuarioPaciente(int pacienteId, string nome, string sobrenome, string email,
                               DateTime? dataNasc, string genero, string cep,
                               string logradouro, string numero, string complemento,
                               string bairro, string cidade, string uf,
                               string contato, decimal? pontos, decimal? descontos)
        {
            PacienteId = pacienteId;
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNasc = dataNasc;
            Genero = genero;
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Uf = uf;
            Contato = contato;
            Pontos = pontos;
            Descontos = descontos;
        }
    }
}
