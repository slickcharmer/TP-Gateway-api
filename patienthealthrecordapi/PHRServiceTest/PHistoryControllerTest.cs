using BusinessLogic;
using Service.Controllers;
using Microsoft.AspNetCore.Mvc;
using PHRModels;
using Models;
using Azure;
using AutoFixture;
using Moq;
using PHRservice.Controllers;

namespace PHRServiceTest
{
    public class PHistoryControllerTest
    {
        private readonly IFixture fixture;
        private readonly Mock<ILogic> mocklogic;
        private readonly HistoryController controller;

        public PHistoryControllerTest()
        {
            fixture = new Fixture();
            mocklogic = fixture.Freeze<Mock<ILogic>>();
            controller = new HistoryController(mocklogic.Object);
        }

        [Fact]
        public void GetAlls_ReturnsOk()
        {
            // Arrange
            var id = "test-id";

            // Act
            var result = controller.GetAlls(id);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetBasics_ReturnsOk()
        {
            // Arrange
            var pid = "test-pid";
            var aid = "test-aid";

            // Act
            var result = controller.GetBasics(pid, aid);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
