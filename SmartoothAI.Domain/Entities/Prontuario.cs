namespace SmartoothAI.Domain.Entities
{
    public class Prontuario
    {
        public int ProntuarioId { get; set; }

        public string Prescricao { get; set; }

        public string Observacoes { get; set; }

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
