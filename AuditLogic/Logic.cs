using AuditFluentApi.Entites;
using AuditLogic;
using AuditModels;

namespace AuditLogic
{
    public class Logic : ILogic
    {
        readonly IRepo<Audit> repo;

        public Logic(IRepo<Audit> repo)
        {
            this.repo = repo;
        }

        public Audit AddAudit(Audit newAudit)
        {
            try
            {
                repo.Add(newAudit);
                return newAudit;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Audit> GetAllAudits()
        {
            return repo.GetAudits();
        }

        public IEnumerable<Audit> GetPatientAudits(string healthId)
        {
            try
            {
                return repo.GetAudits().Where(a => a.HealthId == healthId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}