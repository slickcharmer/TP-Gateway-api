using DataLayer.Entities;

namespace DataLayer
{
    public class DoctorEFRepo : IDoctorRepo
    {
        private readonly ManojDbContext _context;
        public DoctorEFRepo(ManojDbContext context)
        {
            _context = context;
        }

        public string AddDoctor(Doctor doctor)
        {
            try
            {
                if (doctor != null)
                {
                    _context.Add(doctor);
                    _context.SaveChanges();
                    return "1";
                }
                else
                {
                    return "-1";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return "-1";
            
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            try
            {
                var doc = _context.Doctors;
                var res = (from d in doc
                           select new Doctor
                           {
                               Id = d.Id,
                               Name = d.Name,
                               Email = d.Email,
                               Gender = d.Gender,
                               Specialization = d.Specialization,
                               ImgUrl = d.ImgUrl,
                               Experience = d.Experience,
                               PhoneNo = d.PhoneNo
                           });
                return res.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public IEnumerable<Doctor> GetDoctorByEmail(string email)
        {
            try
            {
                var doc = _context.Doctors;
                var res = (from d in doc
                           where d.Email == email
                           select new DataLayer.Entities.Doctor
                           {
                               Id = d.Id,
                               Name = d.Name,
                               Email = d.Email,
                               Gender = d.Gender,
                               Specialization = d.Specialization,
                               ImgUrl = d.ImgUrl,
                               Experience = d.Experience,
                               PhoneNo = d.PhoneNo
                           });
                return res.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        IEnumerable<DataLayer.Entities.Doctor> IDoctorRepo.GetDoctorById(Guid id)
        {
            try
            {
                var doc = _context.Doctors;
                var res = (from d in doc
                           where d.Id == id
                           select new DataLayer.Entities.Doctor
                           {
                               Id = d.Id,
                               Name = d.Name,
                               Email = d.Email,
                               Gender = d.Gender,
                               Specialization = d.Specialization,
                               ImgUrl = d.ImgUrl,
                               Experience = d.Experience,
                               PhoneNo = d.PhoneNo
                           });
                return res.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}
