using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataLayer;
using dl = DataLayer.Entities;

namespace BusinessLogic
{
    public class Mapper
    {
        public dl.Appointment MapAddAppointmentByPatient(AppointmentModel appointment)
        {
            return new dl.Appointment()
            {
                AppointmentId = appointment.AppointmentId,
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                NurseId = appointment.NurseId,
                Status = appointment.Status,
                Date = appointment.Date,
                

            };
        }
        public dl.Appointment MapUpdateAppointmentByDoctor(AppointmentModel appointment)
        {
            return new dl.Appointment()
            {
                AppointmentId = appointment.AppointmentId,
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                NurseId = appointment.NurseId,
                Status = appointment.Status,
                Date = appointment.Date


            };
        }
    }
}
