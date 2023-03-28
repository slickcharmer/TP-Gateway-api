using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PHRModels;
using ef = PHREntityFrame;
using Models;

namespace PHRServiceTest
{
    public class PHRServiceMapperTest
    {

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

    }
}
