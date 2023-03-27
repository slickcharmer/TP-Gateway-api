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

        public string Add(PatientLogin patientLogin)
        {
            try
            {
                var user = context.PatientLogins.Where(p=>p.Email == patientLogin.Email).Any();
                if (user)
                {
                    return "-1";
                }
                else
                {
                    context.PatientLogins.Add(patientLogin);
                    context.SaveChanges();
                    return "1";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return "-1";
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