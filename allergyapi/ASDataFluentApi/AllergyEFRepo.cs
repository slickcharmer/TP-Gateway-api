namespace DataFluentApi.Entities
{
    public class AllergyEFRepo : IEFRepo
    {
        AllergyServiceDbContext context;
        public AllergyEFRepo(AllergyServiceDbContext context)
        {
            this.context = context;
        }

        public List<Allergy> GetAllData()
        {
            return context.Allergies.ToList();
        }

        public Allergy Add(Allergy entity)
        {
            context.Allergies.Add(entity);
            context.SaveChanges();
            return entity;
        }

    }
}