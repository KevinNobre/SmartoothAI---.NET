namespace Smartooth.Domain.Entities
{
    public class Profissional
    {
        public int ProfissionalId { get; set; }

        public string Nome { get; set; }

        public string Especialidade { get; set; }

        public string Experiencia { get; set; }

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
