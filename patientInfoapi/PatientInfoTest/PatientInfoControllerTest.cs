using Capstoneproj_patientinfo.Controllers;
using AutoFixture;
using BuisnessLogic;
using Moq;
using Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using PIDataLogic.Entities;

namespace PatientInfoTest
{
    public class PatientInfoControllerTest
    {

        private readonly IFixture fixture;
        private readonly Mock<ILogic> logic;
        private readonly PatientInfoController controller;


        public PatientInfoControllerTest()
        {
            fixture = new Fixture();
            logic = fixture.Freeze<Mock<ILogic>>(); ;
            controller = new PatientInfoController(logic.Object);

        }
        [Fact]
        public void GetAll_OK()
        {
            var mock = fixture.Create<IEnumerable<PatientInfo>>();
            logic.Setup(x => x.GetallPatientinfos()).Returns(mock);

            var result = controller.GetallPatientInfo(); ;

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value
                .Should().NotBeNull()
                .And.BeOfType(mock.GetType());
            logic.Verify(x => x.GetallPatientinfos(), Times.AtLeastOnce());
        }


        [Fact]
        public void GetAll_BadRequest()
        {
            var ex = new ArgumentException("Test Exception");
            logic.Setup(x => x.GetallPatientinfos()).Throws(ex);

            // Act
            var result = controller.GetallPatientInfo();

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            var badRequestResult = result as BadRequestObjectResult;
            Assert.Equal(ex.Message, badRequestResult.Value);
        }

        [Fact]
        public void GetPatientInfobyemail_Ok()
        {
            var mock = fixture.Create<IEnumerable<PatientInfo>>();
            logic.Setup(x => x.GetPatientDetailsByemail(It.IsAny<string>())).Returns(mock);

            // Act
            var result = controller.GetPatientInfobyemail("test@example.com");

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal(mock, okResult.Value);
        }

        [Fact]
        public void GetPatientInfobyemail_BadRequest()
        {
            var ex = new ArgumentException("Test Exception");
            logic.Setup(x => x.GetPatientDetailsByemail(It.IsAny<string>())).Throws(ex);

            // Act
            var result = controller.GetPatientInfobyemail("test@example.com");

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            var badRequestResult = result as BadRequestObjectResult;
            Assert.Equal(ex.Message, badRequestResult.Value);
        }

        [Fact]
        public void GetPatientInfobyID_Ok()
        {
            var mock = fixture.Create<PatientInfo>();
            logic.Setup(x => x.GetPatientDetailsById(It.IsAny<Guid>())).Returns(mock);

            // Act
            var result = controller.GetPatientInfobyId(Guid.NewGuid());

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal(mock, okResult.Value);
        }

        [Fact]
        public void GetPatientInfobyID_BadRequest()
        {
            var ex = new ArgumentException("Test Exception");
            logic.Setup(x => x.GetPatientDetailsById(It.IsAny<Guid>())).Throws(ex);

            // Act
            var result = controller.GetPatientInfobyId(Guid.NewGuid());

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            var badRequestResult = result as BadRequestObjectResult;
            Assert.Equal(ex.Message, badRequestResult.Value);
        }

        [Fact]
        public void PostPatientInfo_CreatedResult()
        {
            // Arrange
            logic.Setup(x => x.AddnewPatientInfo(It.IsAny<Patientinfo>())).Returns("1");
            var patientinfo = new Patientinfo() { };

            // Act
            var result = controller.PostPatientInfo(patientinfo);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("Added", createdResult.ActionName);
            Assert.Equal(patientinfo, createdResult.Value);
        }

        [Fact]
        public void PostPatientInfo_BadRequest()
        {
            // Arrange
            logic.Setup(x => x.AddnewPatientInfo(It.IsAny<Patientinfo>())).Returns("Error adding patient info");

            var patientinfo = new Patientinfo()
            {
            };

            // Act
            var result = controller.PostPatientInfo(patientinfo);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Error adding patient info", badRequestResult.Value);
        }

        [Fact]
        public void PostPatientInfo_BadRequest_excep()
        {
            // Arrange
            logic.Setup(x => x.AddnewPatientInfo(It.IsAny<Patientinfo>())).Throws(new Exception("Exception message"));

            var patientinfo = new Patientinfo()
            {
            };

            // Act
            var result = controller.PostPatientInfo(patientinfo);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Exception message", badRequestResult.Value);
        }

        // Test method for Created response
        [Fact]
        public void UpdatepatientInfo_Created()
        {
            // Arrange
            var mock = fixture.Create<PatientInfo>();

            logic.Setup(x => x.updatePatientinfos(It.IsAny<Guid>(), It.IsAny<Patientinfo>())).Returns(mock);

            // Act
            var result = controller.UpdatepatientInfo(Guid.NewGuid(), new Patientinfo());

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("Added", createdResult.ActionName);
            Assert.IsType<Patientinfo>(createdResult.Value);
        }

        [Fact]
        public void UpdatepatientInfo_BadRequest()
        {
            // Arrange
            var mock = fixture.Create<PatientInfo>();
            logic.Setup(x => x.updatePatientinfos(It.IsAny<Guid>(), It.IsAny<Patientinfo>())).Throws(new Exception("Error updating patient info."));

            // Act
            var result = controller.UpdatepatientInfo(Guid.NewGuid(), new Patientinfo());

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<string>(badRequestResult.Value);
            Assert.Equal("Error updating patient info.", badRequestResult.Value);
        }




    }
}