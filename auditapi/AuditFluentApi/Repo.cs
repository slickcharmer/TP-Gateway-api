using AuditFluentApi.Entites;
using AuditModels;

namespace AuditFluentApi
{
    public class Repo : IRepo<Audit>
    {
        AuditServiceContext context;

        public Repo(AuditServiceContext context)
        {
            this.context = context;
        }

        public Audit Add(Audit audit)
        {
            try
            {
                context.Add(audit);
                context.SaveChanges();
                return audit;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Audit> GetAudits()
        {
            return context.Audits.ToList();
        }
    }
}
