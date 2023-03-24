using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using dl = DataLayer.Entities;

namespace BusinessLogic
{
    public interface ILogic
    {
        public void AddAppointmentByPatient(AppointmentModel appointment);
        public dl.Appointment UpdateStatusByDoctor(Guid id, short status);
        public dl.Appointment UpdateNurseIdByNurse(Guid id, string nurse_id);
        public IEnumerable<AppointmentModel> GetAppointmentsByDoctorId(string doctor_id);
        public IEnumerable<AppointmentModel> GetAppointmentsByStatus(short status);
        public IEnumerable<AppointmentModel> GetAppointmentsByStatusOne();
    }
}
