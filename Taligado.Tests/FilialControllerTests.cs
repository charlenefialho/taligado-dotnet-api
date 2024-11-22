using Microsoft.AspNetCore.Mvc;
using Moq;
using Taligado.Controllers;
using Taligado.Models;
using Taligado.Repositories;

namespace Taligado.Tests
{
    public class FilialControllerTests
    {
        private readonly Mock<IRepository<Filial>> _mockRepo;
        private readonly FilialController _controller;

        public FilialControllerTests()
        {
            _mockRepo = new Mock<IRepository<Filial>>();
            _controller = new FilialController(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllFiliais()
        {
            var filiais = new List<Filial> { new Filial { IdFilial = 1, Nome = "Filial Teste" } };
            _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(filiais);

            var result = await _controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Filial>>(okResult.Value);
            Assert.Single(returnValue);
        }
    }

}
