namespace SmartoothAI.Domain.Entities
{
    public class SistemaPontos
    {
        public int PontosId { get; set; }

        public decimal? TotalPontos { get; set; }

        public string TipoPontos { get; set; }

        public int PlanoId { get; set; }

        public SistemaPontos()
        { }

        public SistemaPontos(int pontosId, decimal? totalPontos, string tipoPontos, int planoId)
        {
            PontosId = pontosId;
            TotalPontos = totalPontos;
            TipoPontos = tipoPontos;
            PlanoId = planoId;
        }
    }
}