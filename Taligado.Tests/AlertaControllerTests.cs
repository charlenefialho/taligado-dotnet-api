using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taligado.Controllers;
using Taligado.Models;
using Taligado.Repositories;

namespace Taligado.Tests
{
    public class AlertaControllerTests
    {
        private readonly Mock<IRepository<Alerta>> _mockRepo;
        private readonly AlertaController _controller;

        public AlertaControllerTests()
        {
            _mockRepo = new Mock<IRepository<Alerta>>();
            _controller = new AlertaController(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllAlertas()
        {
            var alertas = new List<Alerta> { new Alerta { IdAlerta = 1, Descricao = "Teste Alerta" } };
            _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(alertas);

            var result = await _controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Alerta>>(okResult.Value);
            Assert.Single(returnValue);
        }
    }

}
