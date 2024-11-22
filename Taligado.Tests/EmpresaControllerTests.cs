using Microsoft.AspNetCore.Mvc;
using Moq;
using Taligado.Controllers;
using Taligado.Models;
using Taligado.Repositories;

namespace Taligado.Tests
{
    public class EmpresaControllerTests
    {
        private readonly Mock<IRepository<Empresa>> _mockRepo;
        private readonly EmpresaController _controller;

        public EmpresaControllerTests()
        {
            _mockRepo = new Mock<IRepository<Empresa>>();
            _controller = new EmpresaController(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnEmpresas()
        {
            // Arrange
            var empresas = new List<Empresa> { new Empresa { IdEmpresa = 1, Nome = "Empresa 1" } };
            _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(empresas);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Empresa>>(okResult.Value);
            Assert.Single(returnValue);
        }

        [Fact]
        public async Task Update_ShouldReturnNoContent_WhenEmpresaExists()
        {
            // Arrange
            var empresa = new Empresa { IdEmpresa = 1, Nome = "Empresa Teste" };
            _mockRepo.Setup(repo => repo.GetByIdAsync(empresa.IdEmpresa)).ReturnsAsync(empresa);

            // Act
            var result = await _controller.Update(empresa.IdEmpresa, empresa);

            // Assert
            Assert.IsType<NoContentResult>(result);
            _mockRepo.Verify(repo => repo.UpdateAsync(empresa), Times.Once);
        }

        [Fact]
        public async Task Delete_ShouldReturnNoContent_WhenEmpresaExists()
        {
            // Arrange
            var empresa = new Empresa { IdEmpresa = 1, Nome = "Empresa Teste" };
            _mockRepo.Setup(repo => repo.GetByIdAsync(empresa.IdEmpresa)).ReturnsAsync(empresa);

            // Act
            var result = await _controller.Delete(empresa.IdEmpresa);

            // Assert
            Assert.IsType<NoContentResult>(result);
            _mockRepo.Verify(repo => repo.DeleteAsync(empresa.IdEmpresa), Times.Once);
        }
    }

}