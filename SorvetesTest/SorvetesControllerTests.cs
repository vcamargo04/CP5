using SorvetesRepository;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Moq;
using Xunit;
using SorveteriaAPI.Controllers;
using SorveteriaModel.DTO;
using SorveteriaModel;

namespace SorvetesTest
{
    public class SorvetesControllerTests
    {
        private readonly Mock<IRepository<Sorvete>> _mockRepository;
        private readonly SorvetesController _controller;

        public SorvetesControllerTests()
        {
            _mockRepository = new Mock<IRepository<Sorvete>>();
            _controller = new SorvetesController(_mockRepository.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult_WithSorvetes()
        {
            // Arrange
            var sorvetes = new List<Sorvete> { new Sorvete { Id = ObjectId.GenerateNewId(), Nome = "Sorvete 1" } };
            _mockRepository.Setup(repo => repo.GetAll()).ReturnsAsync(sorvetes);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsAssignableFrom<List<SorveteResponse>>(okResult.Value);
            Assert.Single(returnValue);
        }

        [Fact]
        public async Task Get_ReturnsNotFound_WhenSorveteDoesNotExist()
        {
            // Arrange
            var invalidId = "invalid_id";
            _mockRepository.Setup(repo => repo.GetById(It.IsAny<ObjectId>())).ReturnsAsync((Sorvete)null);

            // Act
            var result = await _controller.Get(invalidId);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Post_ReturnsOkResult_WhenSorveteIsAdded()
        {
            // Arrange
            var sorveteRequest = new SorveteRequest { Nome = "Novo Sorvete" };
            var sorvete = new Sorvete { Id = ObjectId.GenerateNewId(), Nome = sorveteRequest.Nome };
            _mockRepository.Setup(repo => repo.Add(It.IsAny<Sorvete>())).Returns(Task.CompletedTask);
            _mockRepository.Setup(repo => repo.GetById(sorvete.Id)).ReturnsAsync(sorvete);

            // Act
            var result = await _controller.Post(sorveteRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<SorveteResponse>(okResult.Value);
            Assert.Equal(sorveteRequest.Nome, returnValue.Nome);
        }

        [Fact]
        public async Task Put_ReturnsNotFound_WhenSorveteDoesNotExist()
        {
            // Arrange
            var invalidId = "invalid_id";
            var sorveteRequest = new SorveteRequest { Nome = "Updated Sorvete" };
            _mockRepository.Setup(repo => repo.GetById(It.IsAny<ObjectId>())).ReturnsAsync((Sorvete)null);

            // Act
            var result = await _controller.Put(invalidId, sorveteRequest);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsNotFound_WhenSorveteDoesNotExist()
        {
            // Arrange
            var invalidId = "invalid_id";
            _mockRepository.Setup(repo => repo.GetById(It.IsAny<ObjectId>())).ReturnsAsync((Sorvete)null);

            // Act
            var result = await _controller.Delete(invalidId);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
