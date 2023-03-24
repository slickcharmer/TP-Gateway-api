using DataLayer.Entities;

namespace DataLayer
{
    public class NurseEFRepo : INurseRepo
    {
        private readonly ManojDbContext _context;
        public NurseEFRepo(ManojDbContext context)
        {
            _context = context;
        }

        public string AddNurse(Nurse nurse)
        {
            try
            {
                if (nurse != null)
                {
                    _context.Add(nurse);
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

        public IEnumerable<Nurse> GetAllNurse()
        {
            try
            {
                var nur = _context.Nurses;
                var res = (from n in nur
                           select new DataLayer.Entities.Nurse
                           {
                               Id = n.Id,
                               Name = n.Name,
                               Email = n.Email,
                               PhoneNo = n.PhoneNo,
                           });
                return res.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public IEnumerable<Nurse> GetNurseByEmail(string email)
        {
            try
            {
                var doc = _context.Nurses;
                var res = (from d in doc
                           where d.Email == email
                           select new DataLayer.Entities.Nurse
                           {
                               Id = d.Id,
                               Name = d.Name,
                               Email = d.Email,
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
