using AutoFixture;
using AvailabilityApiService.Controllers;
using BusinessLogic;
using FluentApi.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AvailabilityServiceTest
{
    public class PhysicianAvailabilityControllerTest
    {
        private readonly IFixture fixture;
        private readonly Mock<ILogic> mlogic;
        private readonly PhysicianAvailabilityController controller;
        public PhysicianAvailabilityControllerTest()
        {
            fixture = new Fixture();
            mlogic = fixture.Freeze<Mock<ILogic>>();
            controller = new PhysicianAvailabilityController(mlogic.Object);

        }
        [Fact]
        public void Get_Availabilityservice_OK_Test()
        {
            //Arrange
            var phrmock = fixture.Create<IEnumerable<FluentApi.Entities.DoctorSchedule>>();
            var id = fixture.Create<string>();
            mlogic.Setup(x => x.GetSchedule(id)).Returns(phrmock);
            //Act
            var result = controller.Get(id);

            //Assert

            result.Should().NotBeNull();

            result.Should().BeAssignableTo<OkObjectResult>();

            result.As<OkObjectResult>().Value
                .Should().NotBeNull()
                .And.BeOfType(phrmock.GetType());

            mlogic.Verify(x => x.GetSchedule(id), Times.AtLeastOnce());
        }
        [Fact]
        public void Get_AvailabilityService_BadRequest_Test()
        {
            //Arrange
            IEnumerable<FluentApi.Entities.DoctorSchedule> phrmock = null;
            var id = fixture.Create<string>();
            mlogic.Setup(x => x.GetSchedule(id)).Returns(phrmock);
            //Act
            var result = controller.Get(id);

            //Assert

            result.Should().BeAssignableTo<BadRequestObjectResult>();

            mlogic.Verify(x => x.GetSchedule(id), Times.AtLeastOnce());
        }
        [Fact]
        public void Get_AvailabiliityService_ExceptionTest()
        {
            var id = fixture.Create<string>();
            mlogic.Setup(x => x.GetSchedule(id)).Throws(new Exception("Something wrong with the request"));

            var result = controller.Get(id);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mlogic.Verify(x => x.GetSchedule(id), Times.AtLeastOnce());

        }
        [Fact]
        public void Add_AvailabilityService_OKTest()
        {
            var hr = fixture.Create<DoctorSchedule>();
            mlogic.Setup(x => x.AddSchedule(hr));

            var result = controller.Add(hr);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<CreatedAtActionResult>();
            result.As<CreatedAtActionResult>().Value.Should().NotBeNull().And.BeOfType(hr.GetType());
            mlogic.Verify(x => x.AddSchedule(hr), Times.AtLeastOnce());
        }
        [Fact]
        public void Add_AvailabilityService_BadRequestTest()
        {
            var hr = fixture.Create<DoctorSchedule>();
            mlogic.Setup(x => x.AddSchedule(hr)).Throws(new Exception("Something went wrong"));

            var result = controller.Add(hr);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mlogic.Verify(x => x.AddSchedule(hr), Times.AtLeastOnce());

        }
        [Fact]
        public void Add_AvailabilityService_ExceptionTest()
        {
            DoctorSchedule hr = null;
            mlogic.Setup(x => x.AddSchedule(hr)).Throws(new Exception("Something wrong with the request"));

            var result = controller.Add(hr);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mlogic.Verify(x => x.AddSchedule(hr), Times.AtLeastOnce());
        }
        [Fact]
        public void Update_AvailabilityService_OKTest()
        {
            var id = fixture.Create<int>();
            var hr = fixture.Create<IEnumerable<DoctorSchedule>>();
            mlogic.Setup(x => x.UpdateAllDoctors(id,hr));

            var result = controller.UpdateAll(id,hr);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value.Should().NotBeNull().And.BeOfType(hr.GetType());
            mlogic.Verify(x => x.UpdateAllDoctors(id,hr), Times.AtLeastOnce());
        }
        [Fact]
        public void Update_AvailabilityService_BadRequestTest()
        {
            var id = fixture.Create<int>();
            var hr = fixture.Create<IEnumerable<DoctorSchedule>>();
            mlogic.Setup(x => x.UpdateAllDoctors(id,hr)).Throws(new Exception("Something went wrong"));

            var result = controller.UpdateAll(id,hr);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mlogic.Verify(x => x.UpdateAllDoctors(id, hr), Times.AtLeastOnce());
        }
        [Fact]
        public void update_AvailabilityService_ExceptionTest()
        {
            var id = fixture.Create<int>();
            IEnumerable<DoctorSchedule> hr = null;
            mlogic.Setup(x => x.UpdateAllDoctors(id, hr)).Throws(new Exception("Something went wrong"));

            var result = controller.UpdateAll(id, hr);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            
        }
    }
}