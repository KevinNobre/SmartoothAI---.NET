namespace SmartoothAI.Application.DTOs
{
    public class UsuarioPacienteDTO
    {
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
    }
}
