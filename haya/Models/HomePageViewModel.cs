namespace haya.Models
{
    public class HomePageViewModel
    {
        public HomeViewModel Home { get; set; } = new();
        public ServicesViewModel Services { get; set; } = new();
        public PortfolioViewModel Portfolio { get; set; } = new();
    }
}
