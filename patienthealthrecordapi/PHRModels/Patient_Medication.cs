using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Patient_Medication
    {
        public Patient_Medication()
        {

        }
        public Guid Id { get; set; }
        public Guid Health_Id { get; set; }
        public string Appointment_Id { get; set; }
        public string Drugs { get; set; }
    }
}
