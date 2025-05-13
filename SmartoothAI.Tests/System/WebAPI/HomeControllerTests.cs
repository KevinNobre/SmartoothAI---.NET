using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SmartoothAI.Controllers;
using SmartoothAI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartoothAI.WebAPI;
using Microsoft.Extensions.Logging;

namespace SmartoothAI.Tests.System.WebAPI
{
    //Testes Unitários de Login
    public class HomeControllerTests
    {
        private HomeController CriarControllerComTempData()
        {
            // Cria mock do logger
            var loggerMock = new Mock<ILogger<HomeController>>();

            // Cria a controller com logger mockado
            var controller = new HomeController(loggerMock.Object);

            // Configura o TempData
            var tempData = new TempDataDictionary(
                new DefaultHttpContext(),
                Mock.Of<ITempDataProvider>()
            );
            controller.TempData = tempData;

            return controller;
        }

        [Fact]
        public void Login_DeveRedirecionarParaAtendimento_QuandoCredenciaisValidas()
        {
            // Arrange
            var controller = CriarControllerComTempData();
            var model = new LoginViewModel
            {
                Usuario = "admin",
                Senha = "admin"
            };

            // Act
            var resultado = controller.Login(model);

            // Assert
            var redirect = Assert.IsType<RedirectToActionResult>(resultado);
            Assert.Equal("Atendimento", redirect.ActionName);
            Assert.Equal("Home", redirect.ControllerName);
        }

        [Fact]
        public void Login_DeveAdicionarErroModelState_QuandoCredenciaisInvalidas()
        {
            // Arrange
            var controller = CriarControllerComTempData();
            var model = new LoginViewModel
            {
                Usuario = "user",
                Senha = "senhaErrada"
            };

            // Act
            var resultado = controller.Login(model);

            // Assert
            var view = Assert.IsType<ViewResult>(resultado);
            Assert.Equal(model, view.Model);
            Assert.False(controller.ModelState.IsValid);
            Assert.True(controller.ModelState.ErrorCount > 0);
        }

        [Fact]
        public void Login_DeveRetornarView_QuandoModelStateInvalido()
        {
            // Arrange
            var controller = CriarControllerComTempData();
            controller.ModelState.AddModelError("Usuario", "Campo obrigatório");

            var model = new LoginViewModel
            {
                Usuario = "", // campo inválido
                Senha = "admin"
            };

            // Act
            var resultado = controller.Login(model);

            // Assert
            var view = Assert.IsType<ViewResult>(resultado);
            Assert.Equal(model, view.Model);
        }
    }
}