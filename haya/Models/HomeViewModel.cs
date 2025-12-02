using haya.Models;
using System.Collections.Generic;

namespace haya.Models
{
    public class HomeViewModel
    {
        public List<ServiceItem> FeaturedServices { get; set; } = new();
    }
}
