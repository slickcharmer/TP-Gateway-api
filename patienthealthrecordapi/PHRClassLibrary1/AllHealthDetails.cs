using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrame
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
        public string Quantity { get; set; }
        public string Test { get; set; }
        public string Result { get; set; }

    }
}
