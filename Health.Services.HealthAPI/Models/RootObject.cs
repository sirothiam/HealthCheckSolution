namespace Health.Services.HealthAPI.Models
{
    public class RootObject
    {
        public List<Result> results { get; set; }
        public Info info { get; set; }
    }
}
