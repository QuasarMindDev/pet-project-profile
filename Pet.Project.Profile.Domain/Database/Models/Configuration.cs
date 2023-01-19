namespace Pet.Project.Profile.Domain.Database.Models
{
    public class Configuration
    {
        public bool DarkTheme { get; set; }
        public string Font { get; set; } = "Times New Roman";
        public int FontSize { get; set; } = 12;
        public NotificationsSettings Settings { get; set; } = new NotificationsSettings();
    }
}