using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dl = DataLayer.Entities;

namespace DataLayer
{
    public interface IEFRepo
    {
        public void AddAppointmentByPatient(dl.Appointment _appointment);
        public dl.Appointment UpdateStatusByDoctor(dl.Appointment _appointment);

        public dl.Appointment UpdateStatusByDoctor(Guid id);

        public dl.Appointment UpdateNurseIdByNurse(dl.Appointment _appointment);

        public dl.Appointment UpdateNurseIdByNurse(Guid id);
        public IEnumerable<AppointmentModel> GetAppointmentsByDoctorId(string doctor_id);
        public IEnumerable<AppointmentModel> GetAppointmentsByNurseId(string nurse_id);
        public IEnumerable<AppointmentModel> GetAppointmentsByStatus(short status);
        public IEnumerable<AppointmentModel> GetAppointmentsByStatusOne();


    }
}
