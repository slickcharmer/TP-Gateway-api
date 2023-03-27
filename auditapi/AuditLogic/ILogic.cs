

using AuditFluentApi.Entites;

namespace AuditLogic
{
    public interface ILogic
    {

        public Audit AddAudit(Audit newAudit);

        public IEnumerable<Audit> GetAllAudits();

        public IEnumerable<Audit> GetPatientAudits(string healthId);

    }
}
