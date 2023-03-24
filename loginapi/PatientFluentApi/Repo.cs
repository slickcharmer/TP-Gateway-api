using Models;
using PatientFluentApi.Entities;

namespace PatientFluentApi
{
    public class Repo : IRepo<PatientLogin>
    {
        PhysicianAvailabilityServiceDbContext context;
        public Repo(PhysicianAvailabilityServiceDbContext context) 
        {
            this.context = context;
        }
        public IEnumerable<PatientLogin> Get()
        {
            return context.PatientLogins;
        }

        public void Add(PatientLogin patientLogin)
        {
            try
            {
                context.PatientLogins.Add(patientLogin);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Update(PatientLogin patientLogin)
        {
            context.PatientLogins.Update(patientLogin);
            context.SaveChanges();
        }

        public void Delete(PatientLogin patientLogin)
        {
            context.PatientLogins.Remove(patientLogin);
            context.SaveChanges();
        }

        public string GetOne(string email, string password)
        {
            try
            {
                var res = context.PatientLogins.Where(i => i.Email == email && i.Password == password).FirstOrDefault();
                if (res != null) return "1";
                else return "0";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return "0";
        }
    }
}