using DataLayer.Entities;
using System.Numerics;

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
                bool flag = false;
                if (doctor != null)
                {
                    if (_context.Doctors.Where(n => n.Email == doctor.Email).Any()) flag = true;
                    if(flag == false)
                    {
                        _context.Add(doctor);
                        _context.SaveChanges();
                        return "1";
                    }
                    else return "-1";
                }
                else
                {
                    return "-2";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return "-2";
        }

        public string Delete(string email)
        {
            try
            {
                var doc = _context.Doctors.Where(d => d.Email == email).FirstOrDefault();
                if (doc != null)
                {
                    _context.Remove(doc);
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

        public Doctor GetDoctorByEmail(string email)
        {
            try
            {
                if (email != null)
                {
                    var doc = _context.Doctors.Where(n => n.Email == email).FirstOrDefault();
                    if (doc != null)
                    {
                        return doc;
                    }
                }
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
