/*using FluentApi.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Mapper
    {
        public static DoctorSchedule EntitySchedule(Models.DoctorSchedule doctorSchedule)
        {
            return new DoctorSchedule()
            {
                DoctorId = doctorSchedule.DoctorId,
                Monday= doctorSchedule.Monday,
                Tuesday= doctorSchedule.Tuesday,
                Wednesday= doctorSchedule.Wednesday,
                Thursday= doctorSchedule.Thursday,
                Friday= doctorSchedule.Friday,
                Saturday= doctorSchedule.Saturday,
                Sunday= doctorSchedule.Sunday,
            };
        }

        public static Models.DoctorSchedule ModelSchedule(DoctorSchedule doctorSchedule)
        {
            return new Models.DoctorSchedule()
            {
                DoctorId = doctorSchedule.DoctorId,
                Monday = doctorSchedule.Monday,
                Tuesday = doctorSchedule.Tuesday,
                Wednesday = doctorSchedule.Wednesday,
                Thursday = doctorSchedule.Thursday,
                Friday = doctorSchedule.Friday,
                Saturday = doctorSchedule.Saturday,
                Sunday = doctorSchedule.Sunday,
            };
        }
    }
}
*/