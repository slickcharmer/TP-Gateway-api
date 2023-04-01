using AutoFixture;
using Moq;
using FluentAssertions;
using BusinessLogic;
using Service.Controllers;
using Microsoft.AspNetCore.Mvc;
using PHRModels;
using Models;
using Azure;

namespace PHRServiceTest
{
    
    public class MedicationControllerTest
    {

        private readonly IFixture fixture;
        private readonly Mock<ILogic> mockLogic;
        private readonly MedicationController controller;
        public MedicationControllerTest()
        {
            fixture = new Fixture();
            mockLogic = fixture.Freeze<Mock<ILogic>>();
            controller = new MedicationController(mockLogic.Object);

        }

        [Fact]
        public void AddMedicalRecords_PHRService_OkResponse()
        {
            var request = fixture.Create<Patient_Medication>();
            mockLogic.Setup(x => x.AddMedicalReport(request));


            var result = controller.Add(request);


            result.Should().NotBeNull();
            result.Should().BeAssignableTo<CreatedAtActionResult>();
            mockLogic.Verify(x => x.AddMedicalReport(request), Times.AtLeastOnce());
        }
        [Fact]
        public void Add_PMedical_Exception()
        {
            var request = fixture.Create<Patient_Medication>();
            mockLogic.Setup(x => x.AddMedicalReport(request)).Throws(new Exception("Something wrong with the request"));

            var result = controller.Add(request);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.AddMedicalReport(request), Times.AtLeastOnce());
        }

        [Fact]
        public void updatemedication_PHRService_OkRequest()
        {
            var request = fixture.Create<Patient_Medication>();
            var id = fixture.Create<string>();
            mockLogic.Setup(x => x.UpdateMedicalReport(id, request)).Returns(request);

            var result = controller.UpdateMedicalRecord(id, request);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value
                .Should().NotBeNull()
                .And.BeOfType(request.GetType());

            mockLogic.Verify(x => x.UpdateMedicalReport(id, request), Times.AtLeastOnce());
        }

        [Fact]
        public void updatemedication_PHRService_Exception()
        {
            var request = fixture.Create<Patient_Medication>();
            var id = fixture.Create<string>();
            mockLogic.Setup(x => x.UpdateMedicalReport(id, request)).Throws(new Exception("Something wrong with the request"));

            var result = controller.UpdateMedicalRecord(id, request);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.UpdateMedicalReport(id, request), Times.AtLeastOnce());
        }

        [Fact]
        public void updatemedication_PHRService_BadRequest()
        {
            //Arrange
            var id = (string)null;
            var patientTest = new Patient_Medication();

            //Act
            var response = controller.UpdateMedicalRecord(id, patientTest);

            //Assert
            response.Should().NotBeNull().And.BeAssignableTo<BadRequestObjectResult>().Which.Value.Should().Be(id);
        }
    }
}
