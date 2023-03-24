using FluentApi.Entities;
using Model = Models;

namespace FluentApi
{
    public class Repo : Model.IRepo<DoctorSchedule>
    {
        private readonly AvailabilityScheduleContext context;

        public Repo(AvailabilityScheduleContext _context)
        {
            context = _context;
        }

        public void Add(DoctorSchedule doctorSchedule)
        {
            context.DoctorSchedules.Add(doctorSchedule);
            context.SaveChanges();
        }

        public void Update(DoctorSchedule doctorSchedule)
        {
            context.DoctorSchedules.Update(doctorSchedule);
            context.SaveChanges();
        }

        public IEnumerable<DoctorSchedule> Get()
        {
            return context.DoctorSchedules.ToList();
        }
    }
}
