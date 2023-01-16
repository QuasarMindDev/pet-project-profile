namespace Pet.Project.Profile.Domain.Database.Models
{
    public class Access
    {
        public string Auth0ID { get; set; } = string.Empty;
        public int FailedCount { get; set; }
    }
}