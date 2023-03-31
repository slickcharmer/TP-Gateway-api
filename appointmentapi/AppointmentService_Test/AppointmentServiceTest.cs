using AutoFixture;
using Moq;
using FluentAssertions;
using AppointmentService_API;
using BusinessLogic;
using AppointmentService_API.Controllers;
using Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using FluentAssertions.Specialized;
using DataLayer.Entities;
using Xunit.Sdk;
using System.Linq;
using System.Reflection;

namespace AppointmentService_Test
{
    public class AppointmentServiceTest
    {
        private readonly IFixture fixture;
        private readonly Mock<ILogic> mockLogic;
        private readonly AppointmentController controller;

        public AppointmentServiceTest()
        {
            fixture = new Fixture();
            mockLogic = fixture.Freeze<Mock<ILogic>>();
            controller = new AppointmentController(mockLogic.Object); // Creates the implementation in-memory
        }

        [Fact]
        public void GetAppointmentsByStatusOne_AppointmentService_OkResponse()
        {
            // Arrange

            var appoinmentMock = fixture.Create<IEnumerable<AppointmentModel>>();
            mockLogic.Setup(x => x.GetAppointmentsByStatusOne()).Returns(appoinmentMock);

            // Act

            var result = controller.GetAppointmentsByStatusOne();


            // Assert

            result.Should().NotBeNull();



            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value
                .Should().NotBeNull()
                .And.BeOfType(appoinmentMock.GetType());
            mockLogic.Verify(x => x.GetAppointmentsByStatusOne(), Times.AtLeastOnce());


        }


        [Fact]
        public void GetAppointmentsByStatusOne_AppointmentService_BadRequestResponse()
        {
            // Arrange
            IEnumerable<AppointmentModel> response = null;

            mockLogic.Setup(x => x.GetAppointmentsByStatusOne()).Returns(response);

            // Act

            var result = controller.GetAppointmentsByStatusOne();


            // Assert



            result.Should().BeAssignableTo<BadRequestObjectResult>();

            mockLogic.Verify(x => x.GetAppointmentsByStatusOne(), Times.AtLeastOnce());



        }

        [Fact]
        public void GetAppointmentsByStatusOne_AppointmentService_Exception()
        {
            var email = fixture.Create<AppointmentModel>();
            var password = fixture.Create<AppointmentModel>();
            mockLogic.Setup(x => x.GetAppointmentsByStatusOne()).Throws(new Exception("Something wrong"));

            var result = controller.GetAppointmentsByStatusOne();

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.GetAppointmentsByStatusOne(), Times.AtLeastOnce());
        }

        [Fact]
        public void GetAppointmentsByDoctorId_AppointmentService_OkResponse()
        {
            // Arrange

            var appoinmentMock = fixture.Create<IEnumerable<AppointmentModel>>();
            var id = fixture.Create<string>();
            mockLogic.Setup(x => x.GetAppointmentsByDoctorId(id)).Returns(appoinmentMock);

            // Act

            var result = controller.GetAppointmentsByDoctorId(id);


            // Assert

            result.Should().NotBeNull();

            //result.Should().BeAssignableTo<ActionResult<AppointmentModel>>();

            result.Should().BeAssignableTo<OkObjectResult>();

            result.As<OkObjectResult>().Value
                .Should().NotBeNull()
                .And.BeOfType(appoinmentMock.GetType());

            mockLogic.Verify(x => x.GetAppointmentsByDoctorId(id), Times.AtLeastOnce());


        }

        [Fact]
        public void GetAppointmentsByDoctorId_AppointmentService_BadRequestResponse()
        {
            // Arrange
            IEnumerable<AppointmentModel> response = null;
            var id = fixture.Create<string>();
            mockLogic.Setup(x => x.GetAppointmentsByDoctorId(id)).Returns(response);

            // Act

            var result = controller.GetAppointmentsByDoctorId(id);


            // Assert



            result.Should().BeAssignableTo<BadRequestObjectResult>();




            mockLogic.Verify(x => x.GetAppointmentsByDoctorId(id), Times.AtLeastOnce());


        }

        [Fact]
        public void GetAppointmentsByDoctorId_AppointmentService_Exception()
        {

            var id = fixture.Create<string>();
            mockLogic.Setup(x => x.GetAppointmentsByDoctorId(id)).Throws(new Exception("Something wrong"));

            var result = controller.GetAppointmentsByDoctorId(id);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.GetAppointmentsByDoctorId(id), Times.AtLeastOnce());

        }

        [Fact]
        public void GetAppointmentsByNurseId_AppointmentService_OkResponse()
        {
            // Arrange

            var appoinmentMock = fixture.Create<IEnumerable<AppointmentModel>>();
            var id = fixture.Create<string>();
            mockLogic.Setup(x => x.GetAppointmentsByNurseId(id)).Returns(appoinmentMock);

            // Act

            var result = controller.GetAppointmentsByNurseId(id);


            // Assert

            result.Should().NotBeNull();

            //result.Should().BeAssignableTo<ActionResult<AppointmentModel>>();

            result.Should().BeAssignableTo<OkObjectResult>();

            result.As<OkObjectResult>().Value
                .Should().NotBeNull()
                .And.BeOfType(appoinmentMock.GetType());

            mockLogic.Verify(x => x.GetAppointmentsByNurseId(id), Times.AtLeastOnce());


        }

        [Fact]
        public void GetAppointmentsByNurseId_AppointmentService_BadRequestResponse()
        {
            // Arrange
            IEnumerable<AppointmentModel> response = null;
            var id = fixture.Create<string>();
            mockLogic.Setup(x => x.GetAppointmentsByNurseId(id)).Returns(response);

            // Act

            var result = controller.GetAppointmentsByNurseId(id);


            // Assert



            result.Should().BeAssignableTo<BadRequestObjectResult>();




            mockLogic.Verify(x => x.GetAppointmentsByNurseId(id), Times.AtLeastOnce());


        }

        [Fact]
        public void GetAppointmentsByNurseId_AppointmentService_Exception()
        {

            var id = fixture.Create<string>();
            mockLogic.Setup(x => x.GetAppointmentsByNurseId(id)).Throws(new Exception("Something wrong"));

            var result = controller.GetAppointmentsByNurseId(id);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.GetAppointmentsByNurseId(id), Times.AtLeastOnce());

        }


        [Fact]
        public void AddAppointment_AppointmentService_OkResponse()
        {
            // Arrange
            var request = fixture.Create<AppointmentModel>();
            var response = fixture.Create<AppointmentModel>();
            mockLogic.Setup(x => x.AddAppointmentByPatient(request));
            // Act
            var result = controller.AddAppointment(request);
            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            mockLogic.Verify(x => x.AddAppointmentByPatient(request), Times.AtLeastOnce());
        }

        [Fact]
        public void AddAppointment_AppointmentService_BadRequestResponse_Exception()
        {
            // Arrange

            Exception exception = new Exception();
            var request = fixture.Create<AppointmentModel>();

            //controller.ModelState.TryAddModelException("Something wrong with the request",exception);




            var response = fixture.Create<AppointmentModel>();
            mockLogic.Setup(x => x.AddAppointmentByPatient(request)).Throws(new Exception("Something wrong with the request"));







            // Act

            var result = controller.AddAppointment(request);


            // Assert

            result.Should().NotBeNull();



            result.Should().BeAssignableTo<BadRequestObjectResult>();




            mockLogic.Verify(x => x.AddAppointmentByPatient(request), Times.AtLeastOnce());


        }


        //[Fact]
        //public void AddAppointment_AppointmentService_BadRequestResponse_SqlException()
        //{
        //    // Arrange

        //    Exception exception = new Exception();
        //    var request = fixture.Create<AppointmentModel>();

        //    //controller.ModelState.TryAddModelException("Something wrong with the request",exception);




        //    var response = fixture.Create<AppointmentModel>();
        //    mockLogic.Setup(x => x.AddAppointmentByPatient(request)).Throws(new new SqlException("Error message"));







        //    // Act

        //    var result = controller.AddAppointment(request);



        //    // Assert

        //    result.Should().NotBeNull();



        //    result.Should().BeAssignableTo<BadRequestObjectResult>();




        //    //mockLogic.Verify(x => x.AddAppointmentByPatient(response), Times.Once());


        //}


        [Fact]
        public void UpdateNurseIdByNurse_AppointmentService_OkResponse()
        {
            // Arrange

            var response = fixture.Create<AppointmentModel>();
            var app_id = fixture.Create<Guid>();
            var nurse_id = fixture.Create<string>();
            //mockLogic.Setup(x => x.AddAppointmentByPatient(request));

            mockLogic.Setup(x => x.UpdateNurseIdByNurse(app_id, nurse_id)).Returns(response);

            // Act

            var result = controller.UpdateNurseIdByNurse(app_id, nurse_id);


            // Assert

            result.Should().NotBeNull();



            result.Should().BeAssignableTo<OkObjectResult>();

            result.As<OkObjectResult>().Value
                .Should().NotBeNull()
                .And.BeOfType(response.GetType());


            mockLogic.Verify(x => x.UpdateNurseIdByNurse(app_id, nurse_id), Times.AtLeastOnce());


        }

        [Fact]
        public void UpdateNurseIdByNurse_AppointmentService_BadRequestResponse()
        {
            // Arrange
            Exception ex = new Exception();

            var app_id = fixture.Create<Guid>();
            var nurse_id = fixture.Create<string>();
            //mockLogic.Setup(x => x.AddAppointmentByPatient(request));

            mockLogic.Setup(x => x.UpdateNurseIdByNurse(app_id, nurse_id)).Throws(new Exception("Something is wrong"));

            // Act

            var result = controller.UpdateNurseIdByNurse(app_id, nurse_id);


            // Assert

            result.Should().NotBeNull();



            result.Should().BeAssignableTo<BadRequestObjectResult>();




            mockLogic.Verify(x => x.UpdateNurseIdByNurse(app_id, nurse_id), Times.AtLeastOnce());


        }



        [Fact]
        public void UpdateStatusByDoctor_AppointmentService_OkResponse()
        {
            // Arrange

            var response = fixture.Create<AppointmentModel>();
            var app_id = fixture.Create<Guid>();
            var status = fixture.Create<short>();
            //mockLogic.Setup(x => x.AddAppointmentByPatient(request));

            mockLogic.Setup(x => x.UpdateStatusByDoctor(app_id, status)).Returns(response);

            // Act

            var result = controller.UpdateStatusByDoctor(app_id, status);



            // Assert

            result.Should().NotBeNull();



            result.Should().BeAssignableTo<OkObjectResult>();

            result.As<OkObjectResult>().Value
                .Should().NotBeNull()
                .And.BeOfType(response.GetType());


            mockLogic.Verify(x => x.UpdateStatusByDoctor(app_id, status), Times.AtLeastOnce());


        }


        [Fact]
        public void UpdateStatusByDoctor_AppointmentService_BadRequestResponse()
        {
            // Arrange
            Exception ex = new Exception();

            var app_id = fixture.Create<Guid>();
            var status = fixture.Create<short>();
            //mockLogic.Setup(x => x.AddAppointmentByPatient(request));

            mockLogic.Setup(x => x.UpdateStatusByDoctor(app_id, status)).Throws(new Exception("Something is wrong"));

            // Act

            var result = controller.UpdateStatusByDoctor(app_id, status);


            // Assert

            result.Should().NotBeNull();



            result.Should().BeAssignableTo<BadRequestObjectResult>();




            mockLogic.Verify(x => x.UpdateStatusByDoctor(app_id, status), Times.AtLeastOnce());


        }


        [Fact]
        public void GetAppointmentsByStatus_AppointmentService_OkResponse()
        {
            // Arrange

            var appoinmentMock = fixture.Create<IEnumerable<AppointmentModel>>();
            var id = fixture.Create<short>();
            mockLogic.Setup(x => x.GetAppointmentsByStatus(id)).Returns(appoinmentMock);

            // Act

            var result = controller.GetAppointmentsByStatus(id);


            // Assert

            result.Should().NotBeNull();

            //result.Should().BeAssignableTo<ActionResult<AppointmentModel>>();

            result.Should().BeAssignableTo<OkObjectResult>();

            result.As<OkObjectResult>().Value
                .Should().NotBeNull()
                .And.BeOfType(appoinmentMock.GetType());

            mockLogic.Verify(x => x.GetAppointmentsByStatus(id), Times.AtLeastOnce());


        }

        [Fact]
        public void GetAppointmentsByStatus_AppointmentService_BadRequestResponse()
        {
            // Arrange

            IEnumerable<AppointmentModel> response = null;
            var id = fixture.Create<short>();
            mockLogic.Setup(x => x.GetAppointmentsByStatus(id)).Returns(response);

            // Act

            var result = controller.GetAppointmentsByStatus(id);


            // Assert



            //result.Should().BeAssignableTo<ActionResult<AppointmentModel>>();

            result.Should().BeAssignableTo<BadRequestObjectResult>();



            mockLogic.Verify(x => x.GetAppointmentsByStatus(id), Times.AtLeastOnce());


        }

        [Fact]
        public void GetAppointmentsByStatus_AppointmentService_Exception()
        {
            var id = fixture.Create<short>();
            mockLogic.Setup(x => x.GetAppointmentsByStatus(id)).Throws(new Exception("Something wrong"));

            var result = controller.GetAppointmentsByStatus(id);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            mockLogic.Verify(x => x.GetAppointmentsByStatus(id), Times.AtLeastOnce());

        }

    }
}