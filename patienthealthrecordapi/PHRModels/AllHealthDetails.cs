using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AllHealthDetails
    {
        public AllHealthDetails()
        {

        }
        public Guid Id { get; set; }
        public DateTime Date_Time { get; set; }
        public string Patient_Id { get; set; }
        public string Doctor_Id { get; set; }
        public string AppointmentId { get; set; }
        public string Conclusion { get; set; }
        public string Health_Id { get; set; }
        public string Drugs { get; set; }
        public string Test { get; set; }
        public string Result { get; set; }

        public string AllHealthDetailRecords()
        {
            return $@"ID:{Id}\n,Date_Time: {Date_Time}\n,Patient_Id: {Patient_Id}\n,Doctor_Id: {Doctor_Id}\n,Health_Id: {Health_Id}\n,Appointment_Id: {AppointmentId}\n,Drugs: {Drugs}\n,Test: {Test}\n,Result: {Result}\n,Conclusion: {Conclusion}\n";
        }
    }
}
