using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using Xunit.Sdk;
using Models;
using dl = DataLayer.Entities;

namespace AppointmentService_Test
{
    public class MapperTest
    {
        Mapper map = new Mapper();



        [Fact]
        public void ModelToEntityTest()
        {
            // Arrange

            AppointmentModel model = new AppointmentModel();


            // Act

            var actualresult = map.MapAddAppointmentByPatient(model);


            // Assert

            Assert.Equal(typeof(dl.Appointment), actualresult.GetType());
        }



        [Fact]
        public void EntityToModelTest()
        {
            // Arrange

            dl.Appointment appointment = new dl.Appointment();


            // Act

            var actualresult = map.MapEntityToModel(appointment);


            // Assert


            Assert.Equal(typeof(AppointmentModel), actualresult.GetType());
        }

        [Fact]
        public void MapTest()
        {
            // Arrange

            AppointmentModel model = new AppointmentModel();


            // Act

            var actualresult = map.MapUpdateAppointmentByDoctor(model);


            // Assert

            Assert.Equal(typeof(dl.Appointment), actualresult.GetType());
        }
    }
}
