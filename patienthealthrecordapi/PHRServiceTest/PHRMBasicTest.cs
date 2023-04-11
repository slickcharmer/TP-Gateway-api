using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using ef = PHREntityFrame;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHRServiceTest
{
    public class AllBasicDetailsTests
    {
        [Fact]
        public void Test()
        {
            // Arrange
            var healthRecord = new Models.AllBasicDetails
            {
                Id = Guid.NewGuid(),
                Date_Time = DateTime.Now,
                Patient_Id = "123",
                Nurse_Id = "456",
                Appointment_Id = "789",
                Bp = "Someconclusion",
                Heart_Rate = 120/80,
                SpO2 = "89",
                Health_Id = "HealthID",
                Allergy = "curd",
                Weight = "78",
                BloodGroup = "O",
                Temperature = "35"
            };

            // Act
            var result = healthRecord.Id;
            var result2 = healthRecord.Date_Time;
            var result3 = healthRecord.Patient_Id;
            var result4 = healthRecord.Nurse_Id;
            var result5 = healthRecord.Appointment_Id;
            var result6 = healthRecord.Bp;
            var result7 = healthRecord.Heart_Rate;
            var result8 = healthRecord.SpO2;
            var result9 = healthRecord.Health_Id;
            var result10 = healthRecord.Allergy;
            var result11 = healthRecord.Weight;
            var result12 = healthRecord.BloodGroup;
            var result13 = healthRecord.Temperature;



            // Assert
            Assert.Equal(healthRecord.Id, result);
            Assert.Equal(healthRecord.Date_Time, result2);
            Assert.Equal(healthRecord.Patient_Id, result3);
            Assert.Equal(healthRecord.Nurse_Id, result4);
            Assert.Equal(healthRecord.Appointment_Id, result5);
            Assert.Equal(healthRecord.Bp, result6);
            Assert.Equal(healthRecord.Health_Id, result9);
            Assert.Equal(healthRecord.SpO2, result8);
            Assert.Equal(healthRecord.Heart_Rate, result7);
            Assert.Equal(healthRecord.Allergy, result10);
            Assert.Equal(healthRecord.Weight, result11);
            Assert.Equal(healthRecord.BloodGroup, result12);
            Assert.Equal(healthRecord.Temperature, result13);
        }
    }



}
