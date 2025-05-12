using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.IO;

namespace SmartoothAI.Controllers
{
    // Usado para treinamento
    public class DadosSentimento
    {
        [LoadColumn(0)] public string Texto { get; set; }
        [LoadColumn(1)] public string Sentimento { get; set; }
    }

    // Usado para entrada da predição
    public class EntradaSentimento
    {
        public string Texto { get; set; }
    }

    // Saída da predição
    public class SentimentoPredito
    {
        [ColumnName("PredictedLabel")]
        public string Sentimento { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class SentimentoController : ControllerBase
    {
        private readonly string caminhoModelo = Path.Combine(Environment.CurrentDirectory, "wwwroot", "MLModels", "SentimentoModel.zip");
        private readonly string caminhoTreinamento = Path.Combine(Environment.CurrentDirectory, "Data", "sentimento-train.csv");
        private readonly MLContext mlContext;

        public SentimentoController()
        {
            mlContext = new MLContext();

            if (!System.IO.File.Exists(caminhoModelo))
            {
                Console.WriteLine("Modelo não encontrado. Iniciando treinamento...");
                TreinarModelo();
            }
        }

        private void TreinarModelo()
        {
            var pastaModelo = Path.GetDirectoryName(caminhoModelo);
            if (!Directory.Exists(pastaModelo))
            {
                Directory.CreateDirectory(pastaModelo);
                Console.WriteLine($"Diretório criado: {pastaModelo}");
            }

            // Carrega os dados do CSV
            IDataView dadosTreinamento = mlContext.Data.LoadFromTextFile<DadosSentimento>(
                path: caminhoTreinamento, hasHeader: true, separatorChar: ',');

            // Define o pipeline de processamento e aprendizado
            var pipeline = mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "Label", inputColumnName: nameof(DadosSentimento.Sentimento))
                .Append(mlContext.Transforms.Text.FeaturizeText(outputColumnName: "Features", inputColumnName: nameof(DadosSentimento.Texto)))
                .Append(mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy())
                .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            // Treina o modelo
            var modelo = pipeline.Fit(dadosTreinamento);

            // Salva o modelo treinado
            mlContext.Model.Save(modelo, dadosTreinamento.Schema, caminhoModelo);
            Console.WriteLine($"Modelo de sentimentos treinado e salvo em: {caminhoModelo}");
        }

        [HttpPost("prever")]
        public ActionResult<SentimentoPredito> PreverSentimento([FromBody] EntradaSentimento entrada)
        {
            if (!System.IO.File.Exists(caminhoModelo))
            {
                return BadRequest("O modelo ainda não foi treinado.");
            }

            // Carrega o modelo treinado
            ITransformer modelo;
            using (var stream = new FileStream(caminhoModelo, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                modelo = mlContext.Model.Load(stream, out var schema);
            }

            // Cria o motor de predição
            var engine = mlContext.Model.CreatePredictionEngine<DadosSentimento, SentimentoPredito>(modelo);

            // Cria um objeto DadosSentimento apenas com o texto
            var dados = new DadosSentimento { Texto = entrada.Texto };

            // Realiza a predição
            var resultado = engine.Predict(dados);

            return Ok(resultado);
        }
    }
}