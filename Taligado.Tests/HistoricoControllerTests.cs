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
    public class HistoricoControllerTests
    {
        private readonly Mock<IRepository<Historico>> _mockRepo;
        private readonly HistoricoController _controller;

        public HistoricoControllerTests()
        {
            _mockRepo = new Mock<IRepository<Historico>>();
            _controller = new HistoricoController(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllHistoricos()
        {
            var historicos = new List<Historico> { new Historico { IdHistorico = 1, ValorConsumoKwh = 100.5 } };
            _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(historicos);

            var result = await _controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Historico>>(okResult.Value);
            Assert.Single(returnValue);
        }
    }

}
