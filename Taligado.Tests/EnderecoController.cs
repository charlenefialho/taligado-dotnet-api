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
    public class EnderecoControllerTests
    {
        private readonly Mock<IRepository<Endereco>> _mockRepo;
        private readonly EnderecoController _controller;

        public EnderecoControllerTests()
        {
            _mockRepo = new Mock<IRepository<Endereco>>();
            _controller = new EnderecoController(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllEnderecos()
        {
            var enderecos = new List<Endereco> { new Endereco { IdEndereco = 1, Logradouro = "Rua Teste" } };
            _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(enderecos);

            var result = await _controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Endereco>>(okResult.Value);
            Assert.Single(returnValue);
        }
    }

}
