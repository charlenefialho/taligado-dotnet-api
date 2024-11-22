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
    public class DispositivoControllerTests
    {
        private readonly Mock<IRepository<Dispositivo>> _mockRepo;
        private readonly DispositivoController _controller;

        public DispositivoControllerTests()
        {
            _mockRepo = new Mock<IRepository<Dispositivo>>();
            _controller = new DispositivoController(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllDispositivos()
        {
            var dispositivos = new List<Dispositivo> { new Dispositivo { IdDispositivo = 1, Nome = "Dispositivo Teste" } };
            _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(dispositivos);

            var result = await _controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Dispositivo>>(okResult.Value);
            Assert.Single(returnValue);
        }
    }

}
