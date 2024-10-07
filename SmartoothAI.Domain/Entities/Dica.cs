namespace SmartoothAI.Domain.Entities
{
    public class Dica
    {
        public int DicaId { get; set; }

        public string Descricao { get; set; }

        public int ProntuarioProntuarioId { get; set; }

        public int UsuarioPacientePacienteId { get; set; }

        public Dica(int dicaId, string descricao, int prontuarioProntuarioId, int usuarioPacientePacienteId)
        {
            DicaId = dicaId;
            Descricao = descricao;
            ProntuarioProntuarioId = prontuarioProntuarioId;
            UsuarioPacientePacienteId = usuarioPacientePacienteId;
        }
    }
}