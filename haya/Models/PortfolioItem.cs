namespace haya.Models
{
    public class PortfolioItem
    {
        public string Title { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;   // Website, Dashboard, IoT, PLC, dll
        public string Description { get; set; } = string.Empty;
        public string TechStack { get; set; } = string.Empty;  // ASP.NET Core, ESP32, dll
        public string Note { get; set; } = string.Empty;       // optional, misal: "Internal project", "Client XYZ"
    }
}