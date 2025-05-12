using Xunit;
using FluentAssertions;
using Moq;
using Microsoft.AspNetCore.Mvc;
using SmartoothAI.Controllers;
using Microsoft.ML;

namespace SmartoothAI.Tests.System.WebAPI
{
    public class SentimentoControllerTests
    {
        private readonly Mock<PredictionEngine<DadosSentimento, SentimentoPredito>> _mockPredictionEngine;
        private readonly SentimentoController _controller;

        public SentimentoControllerTests()
        {
            // Criando o mock do PredictionEngine
            _mockPredictionEngine = new Mock<PredictionEngine<DadosSentimento, SentimentoPredito>>();

            // Configurando o mock para retornar um valor simulado
            _mockPredictionEngine.Setup(engine => engine.Predict(It.IsAny<DadosSentimento>()))
                .Returns(new SentimentoPredito { Sentimento = "Negativo" });

            // Injetando o mock no controlador
            _controller = new SentimentoController();
        }

        [Fact]
        public void POST_Prever_DeveRetornarSentimento_ComSucesso()
        {
            // Arrange
            var entrada = new EntradaSentimento { Texto = "O atendimento foi péssimo e estou muito insatisfeito" };

            // Act
            var resultado = _controller.PreverSentimento(entrada);

            // Assert
            resultado.Should().BeOfType<ActionResult<SentimentoPredito>>(); // Verifica o tipo de retorno
            var okResult = resultado.Result as OkObjectResult; // Verifica se o resultado é Ok (HTTP 200)
            okResult.Should().NotBeNull();

            var sentimento = okResult.Value as SentimentoPredito; // Verifica se o valor retornado é o objeto esperado
            sentimento.Should().NotBeNull();
            sentimento.Sentimento.Should().Be("Negativo");  // Verifica se o sentimento retornado é "Negativo"
        }
    }
}
