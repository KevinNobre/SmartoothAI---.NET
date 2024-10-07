namespace SmartoothAI.Domain.Entities
{
    public class Plano
    {
        public int PlanoId { get; set; }

        public string TipoPlano { get; set; }

        public string Descricao { get; set; }

        public string MarcaPlano { get; set; }

        public string TipoPagamento { get; set; }

        public int UsuarioPacienteId { get; set; }

        public Plano(int planoId, string tipoPlano, string descricao,
                     string marcaPlano, string tipoPagamento, int usuarioPacienteId)
        {
            PlanoId = planoId;
            TipoPlano = tipoPlano;
            Descricao = descricao;
            MarcaPlano = marcaPlano;
            TipoPagamento = tipoPagamento;
            UsuarioPacienteId = usuarioPacienteId;
        }
    }
}