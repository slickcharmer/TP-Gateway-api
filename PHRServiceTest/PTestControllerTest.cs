using AutoFixture;
using Moq;
using FluentAssertions;
using BusinessLogic;
using Service.Controllers;
using Microsoft.AspNetCore.Mvc;
using PHRModels;
using Models;
using Azure;
using Azure.Core;

namespace PHRServiceTest
{

    public class PTestControllerTest
    {

        private readonly IFixture fixture;
        private readonly Mock<ILogic> mockLogic;
        private readonly PTestController controller;
        public PTestControllerTest()
        {
            fixture = new Fixture();
            mockLogic = fixture.Freeze<Mock<ILogic>>();
            controller = new PTestController(mockLogic.Object);

        }

        [Fact]
        public void AddTestRecords_PHRService_OkResponse()
        {
            var request = fixture.Create<Patient_Test>();
            mockLogic.Setup(x => x.AddTestReport(request));


            var result = controller.Add(request);


            result.Should().NotBeNull();
            result.Should().BeAssignableTo<CreatedAtActionResult>();
            mockLogic.Verify(x => x.AddTestReport(request), Times.AtLeastOnce());
        }

        [Fact]
        public void AddTestRecords_PHRService_BadRequest()
        {
            var request = fixture.Create<Patient_Test>();
            mockLogic.Setup(x => x.AddTestReport(request)).Throws(new Exception("Something wrong with the request"));


            var result = controller.Add(request);


            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.AddTestReport(request), Times.AtLeastOnce());
        }

        [Fact]
        public void modifyTest_PHRService_OkRequest()
        {
            var request = fixture.Create<Patient_Test>();
            var id = fixture.Create<string>();
            mockLogic.Setup(x => x.UpdatePatientTest(id, request)).Returns(request);

            var result = controller.UpdateTestRecord(id, request);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value
                .Should().NotBeNull()
                .And.BeOfType(request.GetType());

            mockLogic.Verify(x => x.UpdatePatientTest(id, request), Times.AtLeastOnce());
        }

        [Fact]
        public void modifyTest_PHRService_Exception()
        {
            var request = fixture.Create<Patient_Test>();
            var id = fixture.Create<string>();
            mockLogic.Setup(x => x.UpdatePatientTest(id, request)).Throws(new Exception("Something wrong with the request"));

            var result = controller.UpdateTestRecord(id, request);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.UpdatePatientTest(id, request), Times.AtLeastOnce());
        }

        [Fact]
        public void modifyTest_PHRService_BadRequest()
        {   
            //Arrange
            var id = (string)null;
            var patientTest = new Patient_Test();
            
            //Act
            var response = controller.UpdateTestRecord(id,patientTest);

            //Assert
            response.Should().NotBeNull().And.BeAssignableTo<BadRequestObjectResult>().Which.Value.Should().Be(id);
        }
    }
}
