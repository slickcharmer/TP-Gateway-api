using Moq;
using Models;
using BusinessLogic;
using AutoFixture;
using FluentAssertions;
using PatientFluentApi;
using LoginService.Controllers;
using PatientFluentApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PatientLoginTest
{
    public class PatientLoginTesting
    {


        private readonly IFixture fixture;
        private readonly Mock<ILogic> mockLogic;
        private readonly PatientLoginController controller;

        public PatientLoginTesting()
        {
            fixture = new Fixture();
            mockLogic = fixture.Freeze<Mock<ILogic>>();
            controller = new PatientLoginController(mockLogic.Object); // Creates the implementation in-memory
        }

        [Fact]
        public void GetPatient_PatientLoginController_OkResponse()
        {
            //Arrange

            var pass = fixture.Create<PatientLogin>();
            var email = "geff@gmail.com";
            var password = fixture.Create<string>();
            mockLogic.Setup(x => x.GetPatient(email, password)).Returns("1");
            
            // act
            var result = controller.Get(email,password);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            //result.As<OkObjectResult>().Value
            //    .Should().NotBeNull()
            //    .And.BeOfType();
            //mockLogic.Verify(x => x.GetPatient(email, password), Times.AtLeastOnce());
        }
        [Fact]
        public void GetPatient_PatientLoginController_BadRequest()
        {
            var email = fixture.Create<string>();
            var password = fixture.Create<string>();
            mockLogic.Setup(x => x.GetPatient(email, password)).Throws(new Exception("Something wrong"));

            var result = controller.Get(email, password);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.GetPatient(email, password), Times.AtLeastOnce());
        }
        [Fact]
        public void AddPatient_PatientLoginController_OkResponse()
        {
            //Arrange
            var request = fixture.Create<PatientLogin>();
            mockLogic.Setup(x => x.AddPatient(request)).Returns(request);

            //Act
            var result = controller.Add(request);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<CreatedAtActionResult>();
            mockLogic.Verify(x => x.AddPatient(request), Times.AtLeastOnce());
        }
        [Fact]
        public void AddPatient_AvailabilityService_BadRequest()
        {
            //Arrange
            var request = fixture.Create<PatientLogin>();
            mockLogic.Setup(x => x.AddPatient(request)).Throws(new Exception("Something wrong"));

            //Act
            var result = controller.Add(request);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.AddPatient(request), Times.AtLeastOnce());
        }
        [Fact]
        public void UpdatePatient_AvailabilityService_OkResponse()
        {
            //Arrange
            var response = fixture.Create<PatientLogin>();
            mockLogic.Setup(x => x.UpdatePatient(response)).Returns(response);

            //Act
            var result = controller.Update(response);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value
                .Should().NotBeNull()
                .And.BeOfType(response.GetType());
            mockLogic.Verify(x => x.UpdatePatient(response), Times.AtLeastOnce());
        }
        [Fact]
        public void UpdatePatient_AvailabilityService_BadRequest()
        {
            //Arrange
            var response = fixture.Create<PatientLogin>();
            mockLogic.Setup(x => x.UpdatePatient(response)).Throws(new Exception("Something wrong"));

            //Act
            var result = controller.Update(response);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.UpdatePatient(response), Times.AtLeastOnce());
        }
        [Fact]
        public void DeletePatient_AvailabilityService_OkResponse()
        {
            //Arrange
            string email = "geff@gmail.com";
            var response = fixture.Create<PatientLogin>();
            mockLogic.Setup(x => x.DeletePatient(email)).Returns(response);

            //Act
            var result = controller.Delete(email);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value
                .Should().NotBeNull()
                .And.BeOfType(response.GetType());
            mockLogic.Verify(x => x.DeletePatient(email), Times.AtLeastOnce());
        }
        [Fact]
        public void DeletePatient_AvailabilityService_BadRequest()
        {
            //Arrange
            string email = "geff@gmail.com";
            var response = fixture.Create<PatientLogin>();
            mockLogic.Setup(x => x.DeletePatient(email)).Throws(new Exception("Something wrong"));

            //Act
            var result = controller.Delete(email);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.DeletePatient(email), Times.AtLeastOnce());
        }
    }
}