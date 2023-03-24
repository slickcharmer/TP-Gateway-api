using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Patient_Allergy
    {
        public Patient_Allergy()
        {

        }
        public Guid Id { get; set; }
        public string Health_Id { get; set; }
        public string Appointment_Id { get; set; }
        public string Allergy { get; set; }
    }
}
