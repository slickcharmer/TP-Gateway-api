using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Patient_Health_Record
    {
        public Patient_Health_Record()
        {

        }
        public Guid Id { get; set; }
        public DateTime Date_Time { get; set; }
        public string Patient_Id { get; set; }
        public string Doctor_Id { get; set; }
        public string Appointment_Id { get; set; }
        public string Conclusion { get; set; }

    }
}
