namespace SmartoothAI.Domain.Entities
{
    public class Dica
    {
        public int DicaId { get; set; }

        public string Descricao { get; set; }

        public int ProntuarioId { get; set; }

        public int UsuarioPacienteId { get; set; }

        public Dica(int dicaId, string descricao, int prontuarioProntuarioId, int usuarioPacienteId)
        {
            DicaId = dicaId;
            Descricao = descricao;
            ProntuarioId = prontuarioProntuarioId;
            UsuarioPacienteId = usuarioPacienteId;
        }
    }
}