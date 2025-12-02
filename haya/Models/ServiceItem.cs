namespace haya.Models
{
    public class ServiceItem
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // Teks kecil di badge (misal: Branding, Efficiency, dll)
        public string BadgeText { get; set; } = string.Empty;

        // CSS class untuk warna badge (Bootstrap + custom)
        public string BadgeCss { get; set; } = string.Empty;
    }
}
