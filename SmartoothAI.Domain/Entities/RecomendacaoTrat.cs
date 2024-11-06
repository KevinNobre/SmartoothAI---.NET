using System.ComponentModel.DataAnnotations;

namespace SmartoothAI.Domain.Entities
{
    public class RecomendacaoTrat
    {
        [Key]
        public int RecomendacaoId { get; set; }

        public DateTime? DataRec { get; set; }

        public int PlanoId { get; set; }
        public RecomendacaoTrat()
        { }

        public RecomendacaoTrat(int recomendacaoId, DateTime? dataRec, int planoId) 
        {
            this.RecomendacaoId = recomendacaoId;
            DataRec = dataRec;
            PlanoId = planoId;
        }
    }
}
