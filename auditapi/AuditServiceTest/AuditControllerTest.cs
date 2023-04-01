using AuditFluentApi.Entites;
using AuditLogic;
using AuditService.Controllers;
using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AuditServiceTest
{
    public class AuditControllerTest
    {
        private readonly IFixture fixture;
        private readonly Mock<ILogic> mlogic;
        private readonly AuditServiceController controller;
        public AuditControllerTest()
        {
            fixture = new Fixture();
            mlogic = fixture.Freeze<Mock<ILogic>>();
            controller = new AuditServiceController(mlogic.Object);

        }
        [Fact]
        public void AuditService_Get_OKTest()
        {
            var phrmock = fixture.Create<IEnumerable<Audit>>();
            var id = fixture.Create<string>();
            mlogic.Setup(x => x.GetPatientAudits(id)).Returns(phrmock);
            //Act
            var result = controller.Get(id);

            //Assert

            result.Should().NotBeNull();

            result.Should().BeAssignableTo<OkObjectResult>();

            result.As<OkObjectResult>().Value
                .Should().NotBeNull()
                .And.BeOfType(phrmock.GetType());

            mlogic.Verify(x => x.GetPatientAudits(id), Times.AtLeastOnce());
        }
        [Fact]
        public void get_Auditservice_BadRequest()
        {
            //Arrange
            IEnumerable<Audit> amock = null;
            var id = fixture.Create<string>();
            mlogic.Setup(x => x.GetPatientAudits(id)).Returns(amock);
            //Act
            var result = controller.Get(id);

            //Assert

            result.Should().BeAssignableTo<BadRequestObjectResult>();

            mlogic.Verify(x => x.GetPatientAudits(id), Times.AtLeastOnce());
        }
        [Fact]
        public void get_Auditservice_Exception_Test()
        {
            var id = fixture.Create<string>();
            mlogic.Setup(x => x.GetPatientAudits(id)).Throws(new Exception("Something wrong with the request"));

            var result = controller.Get(id);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mlogic.Verify(x => x.GetPatientAudits(id), Times.AtLeastOnce());
        }
        [Fact]
        public void getAll_Auditservice_OKTest() 
        {
            var phrmock = fixture.Create<IEnumerable<Audit>>();
            mlogic.Setup(x => x.GetAllAudits()).Returns(phrmock);
            //Act
            var result = controller.GetAll();

            //Assert

            result.Should().NotBeNull();

            result.Should().BeAssignableTo<OkObjectResult>();

            result.As<OkObjectResult>().Value
                .Should().NotBeNull()
                .And.BeOfType(phrmock.GetType());

            mlogic.Verify(x => x.GetAllAudits(), Times.AtLeastOnce());
        }
        [Fact]
        public void getAll_Auditservice_BadrequestTest()
        {
            //Arrange
            IEnumerable<Audit> amock = null;
            mlogic.Setup(x => x.GetAllAudits()).Returns(amock);
            //Act
            var result = controller.GetAll();

            //Assert

            result.Should().BeAssignableTo<BadRequestObjectResult>();

            mlogic.Verify(x => x.GetAllAudits(), Times.AtLeastOnce());
        }
        [Fact]
        public void getAll_Auditservice_ExceptionTest() 
        {

            IEnumerable<Audit> response = null;
            mlogic.Setup(x => x.GetAllAudits()).Returns(response);

            var result = controller.GetAll();

            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mlogic.Verify(x => x.GetAllAudits(), Times.AtLeastOnce());
        }
        [Fact]
        public void Add_AuditService_OkTest()
        {
            var request = fixture.Create<Audit>();
            mlogic.Setup(x => x.AddAudit(request));

            var result = controller.Add(request);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<CreatedAtActionResult>();
            mlogic.Verify(x => x.AddAudit(request), Times.AtLeastOnce());
        }
        [Fact]
        public void Add_AuditService_BadRequestTest()
        {
            var request = fixture.Create<Audit>();
            mlogic.Setup(x => x.AddAudit(request)).Throws(new Exception("Something wrong with the request"));
            
            var result = controller.Add(request);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mlogic.Verify(x => x.AddAudit(request), Times.AtLeastOnce());
        }
        [Fact]
        public void Add_AuditService_ExceptionTest()
        {
            var request = fixture.Create<Audit>();
            mlogic.Setup(x => x.AddAudit(request)).Throws(new Exception("Something wrong with the request"));

            var result = controller.Add(request);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mlogic.Verify(x => x.AddAudit(request), Times.AtLeastOnce());
        }
        [Fact]
        public void Add_AuditService_Nullbody_test()
        {
            Audit request = null;
            mlogic.Setup(x => x.AddAudit(request)).Throws(new Exception("Something wrong with the request"));

            var result = controller.Add(request);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            
        }
    }
}