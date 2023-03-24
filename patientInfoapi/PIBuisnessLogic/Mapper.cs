using Models;
using DataLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic
{
    public  class Mapper
    {
        public PatientInfo PatientInfo( Patientinfo patientInfo) {
            return new PatientInfo()
            { 
            PatId= patientInfo.PatId,
            Fullname = patientInfo.Fullname,
            Age= patientInfo.Age,
            Gender= patientInfo.Gender,
            Email= patientInfo.Email,
            Pasword= patientInfo.Pasword,
            Phone= patientInfo.Phone,
            Adress= patientInfo.Adress, 
            State= patientInfo.State,   
            Country= patientInfo.Country,
            };
        }
         public Patientinfo PatientInfo(PatientInfo patientInfo) {
            return new Patientinfo() { 
            PatId= patientInfo.PatId,
            Fullname = patientInfo.Fullname,
            Age= patientInfo.Age,
            Gender= patientInfo.Gender,
            Email= patientInfo.Email,
            Pasword= patientInfo.Pasword,
            Phone= patientInfo.Phone,
            Adress= patientInfo.Adress, 
            State= patientInfo.State,
            Country= patientInfo.Country,
            };
        }
    }
}
