using Models;
using FluentApi.Entities;
using System.Diagnostics;
using System.Linq;

namespace BusinessLogic
{
    public class Logic : ILogic
    {
        IRepo<DoctorSchedule> repo;

        public Logic(IRepo<DoctorSchedule> repo)
        {
            this.repo = repo;
        }

        public void AddSchedule(DoctorSchedule doctorSchedule)
        {
            repo.Add(doctorSchedule);
        }


        public IEnumerable<DoctorSchedule>? GetSchedule(string day) {
            switch (day)
            {
                case "Monday":
                    return repo.Get().Where(s => s.Monday == 1).ToList();
                case "Tuesday":
                    return repo.Get().Where(s => s.Tuesday == 1).ToList();
                case "Wednesday":
                    return repo.Get().Where(s => s.Wednesday == 1).ToList();
                case "Thursday":
                    return repo.Get().Where(s => s.Thursday == 1).ToList();
                case "Friday":
                    return repo.Get().Where(s => s.Friday == 1).ToList();
                case "Saturday":
                    return repo.Get().Where(s => s.Saturday == 1).ToList();
                case "Sunday":
                    return repo.Get().Where(s => s.Sunday == 1).ToList();
                case "All":
                    return repo.Get().ToList();
                default:
                    return null;
            }
            
        }

        public IEnumerable<DoctorSchedule>? UpdateAllDoctors(int day, IEnumerable<DoctorSchedule> allDoctorSchedules)
        {
            List<DoctorSchedule> oldDoctorSchedules = new List<DoctorSchedule>();
            foreach (DoctorSchedule doctorSchedule in allDoctorSchedules)
            {
                DoctorSchedule? oldSchedule = repo.Get().Where(s => s.DoctorId == doctorSchedule.DoctorId).FirstOrDefault();
                if (oldSchedule == null)
                {
                    return null;
                }
                oldDoctorSchedules.Add(oldSchedule);
                switch (day)
                {
                    case 0:
                        oldSchedule.Sunday = doctorSchedule.Sunday;
                        break;
                    case 1:
                        oldSchedule.Monday = doctorSchedule.Monday;
                        break;
                    case 2:
                        oldSchedule.Tuesday = doctorSchedule.Tuesday;
                        break;
                    case 3:
                        oldSchedule.Wednesday = doctorSchedule.Wednesday;
                        break;
                    case 4:
                        oldSchedule.Thursday = doctorSchedule.Thursday;
                        break;
                    case 5:
                        oldSchedule.Friday = doctorSchedule.Friday;
                        break;
                    case 6:
                        oldSchedule.Saturday = doctorSchedule.Saturday;
                        break;
                    default:
                        break;
                }
            }
            repo.Update(oldDoctorSchedules);
            return oldDoctorSchedules;
        }
    }
}