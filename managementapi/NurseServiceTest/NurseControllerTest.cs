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

        [Fact]
        public void GetAll_BadRequest_Test()
        {
            //Arrange
            IEnumerable<Nurse> phrmock = null;
            mockLogic.Setup(x => x.GetAll()).Returns(phrmock);
            //Act
            var result = controller.GetAll();

            //Assert

            result.Should().BeAssignableTo<BadRequestObjectResult>();

            mockLogic.Verify(x => x.GetAll(), Times.AtLeastOnce());
        }
        [Fact]
        public void GetAll_Exception_Test()
        {
            mockLogic.Setup(x => x.GetAll()).Throws(new Exception("Something wrong with the request"));

            var result = controller.GetAll();

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.GetAll(), Times.AtLeastOnce());
        }

        [Fact]
        public void ADD_Test_Created()
        {
            var request = fixture.Create<DataLayer.Entities.Nurse>();
            mockLogic.Setup(x => x.AddNurse(request)).Returns("1");


            var result = controller.Add(request);


            result.Should().NotBeNull();
            result.Should().BeAssignableTo<CreatedResult>();
            mockLogic.Verify(x => x.AddNurse(request), Times.AtLeastOnce());
        }
        [Fact]
        public void ADD_Test_BadRequest1()
        {
            var request = fixture.Create<DataLayer.Entities.Nurse>();
            mockLogic.Setup(x => x.AddNurse(request)).Returns("-1");


            var result = controller.Add(request);


            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.AddNurse(request), Times.AtLeastOnce());
        }
        [Fact]
        public void ADD_Test_BadRequest2()
        {
            var request = fixture.Create<DataLayer.Entities.Nurse>();
            mockLogic.Setup(x => x.AddNurse(request)).Returns("-2");


            var result = controller.Add(request);


            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.AddNurse(request), Times.AtLeastOnce());
        }

        [Fact]
        public void ADD_BadRequest_Test()
        {
            //Arrange
            var doctor = new DataLayer.Entities.Nurse();
            mockLogic.Setup(x => x.AddNurse(doctor)).Returns("0");

            // Act
            var result = controller.Add(doctor);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestResult>();
        }

        [Fact]
        public void Add_Exception_Test()
        {
            //Arrange
            var request = fixture.Create<DataLayer.Entities.Nurse>();
            mockLogic.Setup(x => x.AddNurse(request)).Throws(new Exception("Something wrong with the request"));
            var result = controller.Add(request);


            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestResult>();
            mockLogic.Verify(x => x.AddNurse(request), Times.AtLeastOnce());
        }

        [Fact]
        public void GetByEmail_Test()
        {
            //Arrange
            var phrmock = fixture.Create<IEnumerable<DataLayer.Entities.Nurse>>();
            var email = fixture.Create<string>();
            mockLogic.Setup(x => x.GetByEmail(email)).Returns(phrmock);
            //Act
            var result = controller.GetByEmail(email);

            //Assert

            result.Should().NotBeNull();

            result.Should().BeAssignableTo<OkObjectResult>();

            result.As<OkObjectResult>().Value
                .Should().NotBeNull()
                .And.BeOfType(phrmock.GetType());

            mockLogic.Verify(x => x.GetByEmail(email), Times.AtLeastOnce());
        }

        [Fact]
        public void GetByEmail_BadRequest_Test()
        {
            //Arrange
            IEnumerable<DataLayer.Entities.Nurse> phrmock = null;
            var email = fixture.Create<string>();
            mockLogic.Setup(x => x.GetByEmail(email)).Returns(phrmock);
            //Act
            var result = controller.GetByEmail(email);

            //Assert

            result.Should().BeAssignableTo<BadRequestResult>();

            mockLogic.Verify(x => x.GetByEmail(email), Times.AtLeastOnce());
        }
        [Fact]
        public void GetByEmail_Exception_Test()
        {
            var email = fixture.Create<string>();
            mockLogic.Setup(x => x.GetByEmail(email)).Throws(new Exception("Something wrong with the request"));

            var result = controller.GetByEmail(email);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestResult>();
            mockLogic.Verify(x => x.GetByEmail(email), Times.AtLeastOnce());
        }
    }
}