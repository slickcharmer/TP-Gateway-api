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
    public class AllHealthDetailsTests
    {
        [Fact]
        public void Id()
        {
            // Arrange
            var healthRecord = new Models.AllHealthDetails
            {
                Id = Guid.NewGuid(),
                Date_Time= DateTime.Now,
                Patient_Id = "123",
                Doctor_Id = "456",
                AppointmentId = "789",
                Conclusion = "Someconclusion",
                Health_Id = "HealthID",
                Drugs = "Some drugs",
                Quantity = "Some quantity",
                Test = "Some test",
                Result = "Some result"
            };

            // Act
            var result = healthRecord.Id;
            var result2 = healthRecord.Date_Time;
            var result3 = healthRecord.Patient_Id;
            var result4 = healthRecord.Doctor_Id;
            var result5 = healthRecord.AppointmentId;
            var result6 = healthRecord.Conclusion;
            var result7 = healthRecord.Health_Id;
            var result8 = healthRecord.Drugs;
            var result9 = healthRecord.Quantity;
            var result10 = healthRecord.Test;
            var result11 = healthRecord.Result;



            // Assert
            Assert.Equal(healthRecord.Id, result);
            Assert.Equal(healthRecord.Date_Time, result2);
            Assert.Equal(healthRecord.Patient_Id, result3);
            Assert.Equal(healthRecord.Doctor_Id, result4);
            Assert.Equal(healthRecord.AppointmentId, result5);
            Assert.Equal(healthRecord.Conclusion, result6);
            Assert.Equal(healthRecord.Health_Id, result7);
            Assert.Equal(healthRecord.Drugs, result8);
            Assert.Equal(healthRecord.Quantity, result9);
            Assert.Equal(healthRecord.Test, result10);
            Assert.Equal(healthRecord.Result, result11);
        }
    }



}
