using Models;
using DataLayer;
using dl = DataLayer.Entities;
using DataLayer.Entities;

namespace BusinessLogic
{
    public class Logic : ILogic
    {
        Mapper map = new Mapper();

        IEFRepo repo;

        public Logic(IEFRepo repo)
        {
            this.repo = repo;
        }

        public void AddAppointmentByPatient(AppointmentModel appointment)
        {
            repo.AddAppointmentByPatient(map.MapAddAppointmentByPatient(appointment));
        }

        public IEnumerable<AppointmentModel> GetAppointmentsByDoctorId(string doctor_id)
        {
            return repo.GetAppointmentsByDoctorId(doctor_id);
        }

        public IEnumerable<AppointmentModel> GetAppointmentsByStatus(short status)
        {
            return repo.GetAppointmentsByStatus(status);
        }

        public IEnumerable<AppointmentModel> GetAppointmentsByStatusOne()
        {
            return repo.GetAppointmentsByStatusOne();
        }

        public Appointment UpdateNurseIdByNurse(Guid id, string nurse_id)
        {
            var service = repo.UpdateNurseIdByNurse(id);
            service.NurseId= nurse_id;
            return repo.UpdateNurseIdByNurse(service);
            
        }

        public dl.Appointment UpdateStatusByDoctor(Guid id, short status)
        {
            var service = repo.UpdateStatusByDoctor(id);

            service.Status = status;

            
            return repo.UpdateStatusByDoctor(service);
        }
    }
}