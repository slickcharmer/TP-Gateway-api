namespace PHRModels
{
    public class All
    {
        public string? Patient_ID { get; set; }

        public IEnumerable<Models.AllHealthDetails> HealthDetails { get; set; }
        public IEnumerable<Models.AllBasicDetails> BasicDetails { get; set; }

    }
}
