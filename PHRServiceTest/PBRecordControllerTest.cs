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

    public class PBRecordControllerTest
    {

        private readonly IFixture fixture;
        private readonly Mock<ILogic> mockLogic;
        private readonly PBRecordController controller;
        public PBRecordControllerTest()
        {
            fixture = new Fixture();
            mockLogic = fixture.Freeze<Mock<ILogic>>();
            controller = new PBRecordController(mockLogic.Object);

        }
        [Fact]
        public void GetById_Test()
        {
            //Arrange
            var phrmock = fixture.Create<IEnumerable<EntityFrame.AllBasicDetails>>();
            var id = fixture.Create<string>();
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
            IEnumerable<EntityFrame.AllBasicDetails> phrmock = null;
            var id = fixture.Create<string>();
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
            var id = fixture.Create<string>();
            mockLogic.Setup(x => x.GetById(id)).Throws(new Exception("Something wrong with the request"));

            var result = controller.GetById(id);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.GetById(id), Times.AtLeastOnce());
        }


        [Fact]
        public void AddBasicrecords_PBRService_OkResponse()
        {
            var request = fixture.Create<Patient_Basic_Record>();
            mockLogic.Setup(x => x.AddBasicR(request));


            var result = controller.Add(request);


            result.Should().NotBeNull();
            result.Should().BeAssignableTo<CreatedAtActionResult>();
            mockLogic.Verify(x => x.AddBasicR(request), Times.AtLeastOnce());
        }

        [Fact]
        public void AddBasicRecords_PBRService_BadRequest()
        {
            var request = fixture.Create<Patient_Basic_Record>();
            mockLogic.Setup(x => x.AddBasicR(request)).Throws(new Exception("Something wrong with the request"));
            var result = controller.Add(request);


            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.AddBasicR(request), Times.AtLeastOnce());
        }
        [Fact]
        public void AddBasicRecprd_PBRService_Exception()
        {
            var request = fixture.Create<Patient_Basic_Record>();
            mockLogic.Setup(x => x.AddBasicR(request)).Throws(new Exception("Something wrong with the request"));

            var result = controller.Add(request);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.AddBasicR(request), Times.AtLeastOnce());
        }

        [Fact]
        public void update_PBRService_OkRequest()
        {
            var request = fixture.Create<Patient_Basic_Record>();
            var id = fixture.Create<string>();
            mockLogic.Setup(x => x.UpdateBR(id, request)).Returns(request);

            var result = controller.UpdateBasicRecord(id, request);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value
                .Should().NotBeNull()
                .And.BeOfType(request.GetType());

            mockLogic.Verify(x => x.UpdateBR(id, request), Times.AtLeastOnce());
        }

        [Fact]
        public void updatemedication_PHRService_Exception()
        {
            var request = fixture.Create<Patient_Basic_Record>();
            var id = fixture.Create<string>();
            mockLogic.Setup(x => x.UpdateBR(id, request)).Throws(new Exception("Something wrong with the request"));

            var result = controller.UpdateBasicRecord(id, request);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.UpdateBR(id, request), Times.AtLeastOnce());
        }

        [Fact]
        public void updatemedication_PHRService_BadRequest()
        {
            //Arrange
            var id = (string)null;
            var patientTest = new Patient_Basic_Record();

            //Act
            var response = controller.UpdateBasicRecord(id, patientTest);

            //Assert
            response.Should().NotBeNull().And.BeAssignableTo<BadRequestObjectResult>().Which.Value.Should().Be(id);

        }

    }
}
