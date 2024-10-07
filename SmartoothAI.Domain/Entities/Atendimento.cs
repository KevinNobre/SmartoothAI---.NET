
namespace SmartoothAI.Domain.Entities
{
    public class Atendimento
    {
       public int AtendimentoId { get; set; }

       public string Descricao { get; set; }

       public DateTime? Data { get; set; }

       public TimeSpan? Hora { get; set; }

       public char? InclusoPlano { get; set; }

       public decimal? Custo { get; set; }

       public int ProfissionalId { get; set; }

       public int UsuarioPacienteId { get; set; }

       public int RecomendacaoTratId { get; set; }

        public Atendimento(int atendimentoId, string descricao, DateTime? data, TimeSpan? hora,
                           char? inclusoPlano, decimal? custo, int profissionalId,
                           int usuarioPacienteId, int recomendacaoTratId, int profissionalId1)
        {
            AtendimentoId = atendimentoId;
            Descricao = descricao;
            Data = data;
            Hora = hora;
            InclusoPlano = inclusoPlano;
            Custo = custo;
            ProfissionalId = profissionalId;
            UsuarioPacienteId = usuarioPacienteId;
            RecomendacaoTratId = recomendacaoTratId;
        }
    }
}
