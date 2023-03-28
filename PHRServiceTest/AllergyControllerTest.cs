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
    public class AllergyControllerTest
    {
        private readonly IFixture fixture;
        private readonly Mock<ILogic> mockLogic;
        private readonly PatientAllergyController controller;
        public AllergyControllerTest()
        {
            fixture = new Fixture();
            mockLogic = fixture.Freeze<Mock<ILogic>>();
            controller = new PatientAllergyController(mockLogic.Object);
        }

        [Fact]
        public void AddAllergyRecords_PHRService_OkResponse()
        {
            var request = fixture.Create<Patient_Allergy>();
            mockLogic.Setup(x => x.AddAllergyReport(request));


            var result = controller.Add(request);


            result.Should().NotBeNull();
            result.Should().BeAssignableTo<CreatedAtActionResult>();
            mockLogic.Verify(x => x.AddAllergyReport(request), Times.AtLeastOnce());
        }

        [Fact]
        public void AddAllergyRecords_PHRService_BadRequest()
        {
            var request = fixture.Create<Patient_Allergy>();
            mockLogic.Setup(x => x.AddAllergyReport(request)).Throws(new Exception("Something wrong with the request"));


            var result = controller.Add(request);


            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.AddAllergyReport(request), Times.AtLeastOnce());
        }

        [Fact]
        public void UpdateAllergyRecord_PHRService_OkRequest()
        {
            var request = fixture.Create<Patient_Allergy>();
            var id = fixture.Create<string>();
            mockLogic.Setup(x => x.UpdatePA(id, request)).Returns(request);

            var result = controller.UpdateAllergyRecord(id, request);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value
                .Should().NotBeNull()
                .And.BeOfType(request.GetType());

            mockLogic.Verify(x => x.UpdatePA(id,request),Times.AtLeastOnce());
        }

        [Fact]
        public void UpdateAllergyRecord_PHRService_BadRequest()
        {
            var request = fixture.Create<Patient_Allergy>();
            var id = fixture.Create<string>();
            mockLogic.Setup(x => x.UpdatePA(id, request)).Throws(new Exception("Something wrong with the request"));

            var result = controller.UpdateAllergyRecord(id, request);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.UpdatePA(id, request), Times.AtLeastOnce());
        }
    }
}