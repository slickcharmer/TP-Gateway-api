namespace AuditModels
{
    public interface IRepo<T>
    {
        public T Add(T audit);

        public IEnumerable<T> GetAudits();
    }
}