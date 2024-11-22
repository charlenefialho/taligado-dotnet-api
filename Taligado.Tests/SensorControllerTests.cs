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
    public class SensorControllerTests
    {
        private readonly Mock<IRepository<Sensor>> _mockRepo;
        private readonly SensorController _controller;

        public SensorControllerTests()
        {
            _mockRepo = new Mock<IRepository<Sensor>>();
            _controller = new SensorController(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllSensores()
        {
            var sensores = new List<Sensor> { new Sensor { IdSensor = 1, Tipo = "Temperatura" } };
            _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(sensores);

            var result = await _controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Sensor>>(okResult.Value);
            Assert.Single(returnValue);
        }
    }

}
