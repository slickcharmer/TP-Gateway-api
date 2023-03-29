using Moq;
using DoctorServiceTest;
using FluentAssertions;
using AutoFixture;
using DNApi.Controllers;
using BusinessLogicLayer;
using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace DoctorServiceTest
{
    public class DoctorControllerTest
    {
        private readonly IFixture fixture;
        private readonly Mock<IDoctorLogic> mockLogic;
        private readonly DoctorController controller;
        public DoctorControllerTest()
        {
            fixture = new Fixture();
            mockLogic = fixture.Freeze<Mock<IDoctorLogic>>();
            controller = new DoctorController(mockLogic.Object);

        }
        [Fact]
        public void GetById_Test()
        {
            //Arrange
            var phrmock = fixture.Create<IEnumerable<DataLayer.Entities.Doctor>>();
            var id = fixture.Create<System.Guid>();
            mockLogic.Setup(x => x.GetById(id)).Returns(phrmock);
            //Act
            var result = controller.GetById(id);

            //Assert

            result.Should().NotBeNull();

            result.Should().BeAssignableTo<OkObjectResult>();

            result.As<OkObjectResult>().Value
                .Should().NotBeNull()
                .And.BeOfType(phrmock.GetType());

            mockLogic.Verify(x => x.GetById(id), Times.AtLeastOnce());
        }

        [Fact]
        public void GetById_BadRequest_Test()
        {
            //Arrange
            IEnumerable<DataLayer.Entities.Doctor> phrmock = null;
            var id = fixture.Create<System.Guid>();
            mockLogic.Setup(x => x.GetById(id)).Returns(phrmock);
            //Act
            var result = controller.GetById(id);

            //Assert

            result.Should().BeAssignableTo<BadRequestObjectResult>();

            mockLogic.Verify(x => x.GetById(id), Times.AtLeastOnce());
        }
        [Fact]
        public void GetById_Exception_Test()
        {
            var id = fixture.Create<System.Guid>();
            mockLogic.Setup(x => x.GetById(id)).Throws(new Exception("Something wrong with the request"));

            var result = controller.GetById(id);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.GetById(id), Times.AtLeastOnce());
        }

        [Fact]
        public void GetByEmail_Test()
        {
            //Arrange
            var phrmock = fixture.Create<DataLayer.Entities.Doctor>();
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
            DataLayer.Entities.Doctor phrmock = null;
            var email = fixture.Create<string>();
            mockLogic.Setup(x => x.GetByEmail(email)).Returns(phrmock);
            //Act
            var result = controller.GetByEmail(email);

            //Assert

            result.Should().BeAssignableTo<BadRequestObjectResult>();

            mockLogic.Verify(x => x.GetByEmail(email), Times.AtLeastOnce());
        }
        [Fact]
        public void GetByEmail_Exception_Test()
        {
            var email = fixture.Create<string>();
            mockLogic.Setup(x => x.GetByEmail(email)).Throws(new Exception("Something wrong with the request"));

            var result = controller.GetByEmail(email);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.GetByEmail(email), Times.AtLeastOnce());
        }

        [Fact]
        public void GetAll_Test()
        {
            //Arrange
            var phrmock = fixture.Create<IEnumerable<DataLayer.Entities.Doctor>>();
            mockLogic.Setup(x => x.GetAll()).Returns(phrmock);
            //Act
            var result = controller.GetAll();

            //Assert

            result.Should().NotBeNull();

            result.Should().BeAssignableTo<OkObjectResult>();

            result.As<OkObjectResult>().Value
                .Should().NotBeNull()
                .And.BeOfType(phrmock.GetType());

            mockLogic.Verify(x => x.GetAll(), Times.AtLeastOnce());
        }

        [Fact]
        public void GetAll_BadRequest_Test()
        {
            //Arrange
            IEnumerable<DataLayer.Entities.Doctor> phrmock = null;
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
            var request = fixture.Create<DataLayer.Entities.Doctor>();
            mockLogic.Setup(x => x.AddDoctor(request)).Returns("1");


            var result = controller.Add(request);


            result.Should().NotBeNull();
            result.Should().BeAssignableTo<CreatedResult>();
            mockLogic.Verify(x => x.AddDoctor(request), Times.AtLeastOnce());
        }
        [Fact]
        public void ADD_Test_BadRequest1()
        {
            var request = fixture.Create<DataLayer.Entities.Doctor>();
            mockLogic.Setup(x => x.AddDoctor(request)).Returns("-1");


            var result = controller.Add(request);


            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.AddDoctor(request), Times.AtLeastOnce());
        }
        [Fact]
        public void ADD_Test_BadRequest2()
        {
            var request = fixture.Create<DataLayer.Entities.Doctor>();
            mockLogic.Setup(x => x.AddDoctor(request)).Returns("-2");


            var result = controller.Add(request);


            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.AddDoctor(request), Times.AtLeastOnce());
        }

        [Fact]
        public void ADD_BadRequest_Test()
        {
            //Arrange
            var request = fixture.Create<DataLayer.Entities.Doctor>();
            mockLogic.Setup(x => x.AddDoctor(request)).Throws(new Exception("Something wrong with the request"));
            var result = controller.Add(request);


            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.AddDoctor(request), Times.AtLeastOnce());
        }

        [Fact]
        public void Delete_Test_Created()
        {
            var request = fixture.Create<string>();
            mockLogic.Setup(x => x.DeleteDoctor(request)).Returns("1");


            var result = controller.Delete(request);


            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            mockLogic.Verify(x => x.DeleteDoctor(request), Times.AtLeastOnce());
        }
        [Fact]
        public void Delete_Test_BadRequest()
        {
            var request = fixture.Create<string>();
            mockLogic.Setup(x => x.DeleteDoctor(request)).Returns("-1");


            var result = controller.Delete(request);


            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            mockLogic.Verify(x => x.DeleteDoctor(request), Times.AtLeastOnce());
        }

        [Fact]
        public void Delete_BadRequest_Test()
        {
            //Arrange
            var request = fixture.Create<string>();
            mockLogic.Setup(x => x.DeleteDoctor(request)).Throws(new Exception("Something wrong with the request"));
            var result = controller.Delete(request);


            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.DeleteDoctor(request), Times.AtLeastOnce());
        }
        [Fact]
        public void Delete_Exception_Test()
        {
            var request = fixture.Create<string>();
            mockLogic.Setup(x => x.DeleteDoctor(request)).Throws(new Exception("Something wrong with the request"));

            var result = controller.Delete(request);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.DeleteDoctor(request), Times.AtLeastOnce());
        }
    }
}