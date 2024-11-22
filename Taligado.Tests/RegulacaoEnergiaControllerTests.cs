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
    public class RegulacaoEnergiaControllerTests
    {
        private readonly Mock<IRepository<RegulacaoEnergia>> _mockRepo;
        private readonly RegulacaoEnergiaController _controller;

        public RegulacaoEnergiaControllerTests()
        {
            _mockRepo = new Mock<IRepository<RegulacaoEnergia>>();
            _controller = new RegulacaoEnergiaController(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllRegulacoes()
        {
            var regulacoes = new List<RegulacaoEnergia> { new RegulacaoEnergia { IdRegulacao = 1, NomeBandeira = "Verde" } };
            _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(regulacoes);

            var result = await _controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<RegulacaoEnergia>>(okResult.Value);
            Assert.Single(returnValue);
        }
    }

}
