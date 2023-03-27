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
    }
}
