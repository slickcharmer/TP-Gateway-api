using FluentApi.Entities;

namespace BusinessLogic
{
    public interface ILogic
    {
        public void AddSchedule(DoctorSchedule doctorSchedule);

        public IEnumerable<DoctorSchedule>? GetSchedule(string day);

        public IEnumerable<DoctorSchedule>? UpdateAllDoctors(int day, IEnumerable<DoctorSchedule> allDoctorSchedules);
    }
}
