using System.ComponentModel.DataAnnotations;

namespace SmartoothAI.Domain.Entities
{
    public class UsuarioPaciente
    {
        [Key]
        public int PacienteId { get; set; }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime? DataNasc { get; set; }
        public string Genero { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Contato { get; set; }
        public decimal? Pontos { get; set; }
        public decimal? Descontos { get; set; }

        public UsuarioPaciente()
        {
        }

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
