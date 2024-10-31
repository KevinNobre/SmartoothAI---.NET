namespace SmartoothAI.Domain.Entities
{
    public class Procedimento
    {
        public int ProcedimentoId { get; set; }

        public string NomeProcedimento { get; set; }

        public string Descricao { get; set; }

        public char? InclusaoPlano { get; set; }

        public int ProntuarioId { get; set; }

        public int SistemaPontosId { get; set; }

        public int UsPacienteId { get; set; }
        public Procedimento()
        { }

        public Procedimento(int procedimentoId, string nomeProcedimento, string descricao,
                            char? inclusaoPlano, int prontuarioId, int sistemaPontosId, int usPacienteId)
        {
            ProcedimentoId = procedimentoId;
            NomeProcedimento = nomeProcedimento;
            Descricao = descricao;
            InclusaoPlano = inclusaoPlano;
            ProntuarioId = prontuarioId;
            SistemaPontosId = sistemaPontosId;
            UsPacienteId = usPacienteId;
        }
    }
}