using BusinessLogicLayer;
using DataLayer;
using DataLayer.Entities;
using DNApi;
using DNApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using AutoFixture;
using FluentAssertions;
namespace NurseServiceTest
{
    public class NurseControllerTest
    {

        private readonly IFixture fixture;
        private readonly Mock<INurseLogic> mockLogic;
        private readonly NurseController controller;

        public NurseControllerTest()
        {
            fixture = new Fixture();
            mockLogic = fixture.Freeze<Mock<INurseLogic>>();
            controller = new NurseController(mockLogic.Object); // Creates the implementation in-memory
        }

        [Fact]
        
        public void GetAll_OkResponse()
        {
            // Arrange

            var nurseMock = fixture.Create<IEnumerable<Nurse>>();
            mockLogic.Setup(x => x.GetAll()).Returns(nurseMock);

            // Act

            var result = controller.GetAll();


            // Assert

            result.Should().NotBeNull();



            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value
                .Should().NotBeNull()
                .And.BeOfType(nurseMock.GetType());
            mockLogic.Verify(x => x.GetAll(), Times.AtLeastOnce());


        }
    }
}