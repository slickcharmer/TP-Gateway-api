using DataLayer.Entities;
using Microsoft.Data.SqlClient;
using Models;

namespace DataLayer
{
    public class AppointmentEFRepo : IEFRepo
    {

        AppointmentServiceDbContext context = new AppointmentServiceDbContext();

        public AppointmentEFRepo(AppointmentServiceDbContext context)
        {
            this.context = context;
        }

        public void AddAppointmentByPatient(Appointment _appointment)
        {
            
            context.Appointments.Add(_appointment);
            context.SaveChanges();
        }

        public IEnumerable<AppointmentModel> GetAppointmentsByDoctorId(string doctor_id)
        {
            var doctor = context.Appointments;
            var doctor_det = (
                from dr in doctor
                where dr.DoctorId == doctor_id
                select new AppointmentModel()
                {
                    AppointmentId = dr.AppointmentId,
                    PatientId = dr.PatientId,
                    DoctorId = dr.DoctorId,
                    NurseId = dr.NurseId,
                    Status = dr.Status,
                    Date = dr.Date
                }


                );
            return doctor_det.ToList(); 
        }

        public IEnumerable<AppointmentModel> GetAppointmentsByNurseId(string nurse_id)
        {
            var nurse = context.Appointments;
            var nurse_det = (
                from nr in nurse
                where nr.NurseId == nurse_id
                select new AppointmentModel()
                {
                    AppointmentId = nr.AppointmentId,
                    PatientId = nr.PatientId,
                    DoctorId = nr.DoctorId,
                    NurseId = nr.NurseId,
                    Status = nr.Status,
                    Date = nr.Date,



                }
                );
            return nurse_det.ToList();
        }

        public IEnumerable<AppointmentModel> GetAppointmentsByStatus(short status)
        {
            var _status = context.Appointments;
            var status_det = (from st in _status
                              where st.Status == status
                              select new AppointmentModel()
                              {
                                  AppointmentId= st.AppointmentId,
                                  DoctorId = st.DoctorId,
                                  PatientId = st.PatientId,
                                  NurseId = st.NurseId,
                                  Status = st.Status,
                                  Date = st.Date
                              }
                              );

            return status_det.ToList();
        }

        public IEnumerable<AppointmentModel> GetAppointmentsByStatusOne()
        {
            var _status = context.Appointments;
            var status_det = (from st in _status
                              where st.Status == 1
                              select new AppointmentModel()
                              {
                                  AppointmentId = st.AppointmentId,
                                  DoctorId = st.DoctorId,
                                  PatientId = st.PatientId,
                                  NurseId = st.NurseId,
                                  Status = st.Status,
                                  Date = st.Date
                              }
                              );

            return status_det.ToList();

        }

        public Appointment UpdateNurseIdByNurse(Appointment _appointment)
        {
            context.Appointments.Update(_appointment);
            context.SaveChanges();
            return _appointment;
        }

        public Appointment UpdateNurseIdByNurse(Guid id)
        {
            return context.Appointments.Where(_status => _status.AppointmentId == id).FirstOrDefault();
        }

        public Appointment UpdateStatusByDoctor(Appointment _appointment)
        {
            context.Appointments.Update(_appointment);
            context.SaveChanges();
            return _appointment;
        }

        public Appointment UpdateStatusByDoctor(Guid id)
        {
            return context.Appointments.Where(_status => _status.AppointmentId==id).FirstOrDefault();
        }
    }
}