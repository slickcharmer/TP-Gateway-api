using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PHRModels;
using ef = PHREntityFrame;
using Models;
using PHREntityFrame.Entities;

namespace PHRServiceTest
{
    public class PHRServiceMapperTest
    {

        [Fact]
        public void PBR_EntityToModel()
        {
            ef.Entities.PatientBasicRecord map = new ef.Entities.PatientBasicRecord();
            var result = Mapper.PbMap(map);
            Assert.Equal(result.GetType(), typeof(Patient_Basic_Record));
        }

        [Fact]
        public void PBR_ModelsToEntities()
        {
            Patient_Basic_Record map = new Patient_Basic_Record();
            var result = Mapper.PbMap(map);
            Assert.Equal(result.GetType(), typeof(ef.Entities.PatientBasicRecord));
        }

        [Fact]
        public void Allergy_EntityToModel()
        {
            ef.Entities.PatientAllergy map = new ef.Entities.PatientAllergy();
            var result = Mapper.AMap(map);
            Assert.Equal(result.GetType(), typeof(Patient_Allergy));
        }

        [Fact]
        public void Allergy_ModelsToEntities()
        {
            Patient_Allergy map = new Patient_Allergy();
            var result = Mapper.AMap(map);
            Assert.Equal(result.GetType(),typeof(ef.Entities.PatientAllergy));
        }

        [Fact]
        public void PTest_ModelsToEntities()
        {
            Patient_Test map = new Patient_Test();
            var result = Mapper.TMap(map);
            Assert.Equal(result.GetType(), typeof(ef.Entities.PatientTest));
        }
        [Fact]
        public void PTest_EntityToModel()
        {
            ef.Entities.PatientTest map = new ef.Entities.PatientTest();
            var result = Mapper.TMap(map);
            Assert.Equal(result.GetType(), typeof(Patient_Test));
        }
        [Fact]

        public void PMedication_ModelsToEntities()
        {
            Patient_Medication map = new Patient_Medication();
            var result = Mapper.MrMap(map);
            Assert.Equal(result.GetType(), typeof(ef.Entities.PatientMedication));
        }
        [Fact]
        public void PMedication_EntityToModel()
        {
            ef.Entities.PatientMedication map = new ef.Entities.PatientMedication();
            var result = Mapper.MrMap(map);
            Assert.Equal(result.GetType(), typeof(Patient_Medication));
        }
        [Fact]
        public void PHealth_ModelsToEntities()
        {
            Patient_Health_Record map = new Patient_Health_Record();
            var result = Mapper.HrMap(map);
            Assert.Equal(result.GetType(), typeof(ef.Entities.PatientHealthRecord));
        }
        [Fact]
        public void PHealth_EntitiesToModels()
        {
            ef.Entities.PatientHealthRecord map = new ef.Entities.PatientHealthRecord();
            var result = Mapper.HrMap(map);
            Assert.Equal(result.GetType(), typeof(Patient_Health_Record));
        }

        [Fact]
        public void PbMap_ConvertsPatientBasicRecord()
        {
            // Arrange
            var records = new List<PatientBasicRecord>
        {
            new PatientBasicRecord { Id = Guid.NewGuid(), Bp = "120/80"}
        };
            var expected = new List<Patient_Basic_Record>
        {
            new Patient_Basic_Record { Id = Guid.NewGuid(), Bp = "120/80"}
        };

            // Act
            var actual = Mapper.PbMap(records);

            // Assert
            var expectedRecord = expected.FirstOrDefault();
            var actualRecord = actual.FirstOrDefault();

            Assert.Equal(expectedRecord.Appointment_Id, actualRecord.Appointment_Id);
            Assert.Equal(expectedRecord.Bp, actualRecord.Bp);
        }

        [Fact]
        public void HrMap_ConvertsPatientHealthRecord()
        {
            // Arrange
            var records = new List<PatientHealthRecord>
        {
            new PatientHealthRecord { Id = Guid.NewGuid(), PatientId  = "1" },
        };
            var expected = new List<Patient_Health_Record>
        {
            new Patient_Health_Record { Id = Guid.NewGuid(), Patient_Id="1"}
        };

            // Act
            var actual = Mapper.HrMap(records);

            // Assert
            var expectedRecord = expected.FirstOrDefault();
            var actualRecord = actual.FirstOrDefault();

            Assert.Equal(expectedRecord.Appointment_Id, actualRecord.Appointment_Id);
            Assert.Equal(expectedRecord.Patient_Id, actualRecord.Patient_Id);
        }

        [Fact]
        public void MrMap_ConvertsPatientMedication()
        {
            // Arrange
            var records = new List<PatientMedication>
        {
            new PatientMedication { Id = Guid.NewGuid(), Drug = "Aspirin" }
        };
            var expected = new List<Patient_Medication>
        {
            new Patient_Medication { Id = Guid.NewGuid(), Drugs = "Aspirin" }
        };

            // Act
            var actual = Mapper.MrMap(records);

            // Assert
            var expectedRecord = expected.FirstOrDefault();
            var actualRecord = actual.FirstOrDefault();

            Assert.Equal(expectedRecord.Appointment_Id, actualRecord.Appointment_Id);
            Assert.Equal(expectedRecord.Drugs, actualRecord.Drugs);
        }

        [Fact]
        public void TMap_ConvertsPatientHealthRecord()
        {
            // Arrange
            var records = new List<PatientTest>
        {
            new PatientTest { Result = "good", AppointmentId  = "1" },
        };
            var expected = new List<PatientTest>
        {
            new PatientTest { Result = "good", AppointmentId = "1" }
        };

            // Act
            var actual = Mapper.TMap(records);

            // Assert
            var expectedRecord = expected.FirstOrDefault();
            var actualRecord = actual.FirstOrDefault();

            Assert.Equal(expectedRecord.Result, actualRecord.Result);
            Assert.Equal(expectedRecord.AppointmentId, actualRecord.Appointment_Id);
        }

        [Fact]
        public void AMap_ConvertsPatientMedication()
        {
            // Arrange
            var allergyEntities = new List<ef.Entities.PatientAllergy>
            {
                new ef.Entities.PatientAllergy { Id = Guid.NewGuid(), Allergy = "Peanuts" },
            };

            // Act
            var result = Mapper.AMap(allergyEntities);

            // Assert
            Assert.IsType<List<Models.Patient_Allergy>>(result.ToList());
        }

    }
}
