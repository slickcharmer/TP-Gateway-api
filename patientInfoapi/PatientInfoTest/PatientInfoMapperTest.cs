using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnessLogic;
using Microsoft.EntityFrameworkCore;
using PIDataLogic.Entities;

namespace PatientInfoTest
{
    public class PatientInfoMapperTest
    {
        [Fact]
        public void map1()
        {
            PIDataLogic.Entities.Patientinfo map = new PIDataLogic.Entities.Patientinfo();
            var result = Mapper.PatientInfo(map);
            Assert.Equal(result.GetType(), typeof(Models.PatientInfo));

        }

        [Fact]
        public void map2()
        {
            Models.PatientInfo map = new Models.PatientInfo();
            var result = Mapper.PatientInfo(map);
            Assert.Equal(result.GetType(), typeof(PIDataLogic.Entities.Patientinfo));

        }
    }

}
