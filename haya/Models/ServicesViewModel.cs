using haya.Models;
using System.Collections.Generic;

namespace haya.Models
{
    public class ServicesViewModel
    {
        public List<ServiceItem> Services { get; set; } = new();
        public List<string> Industries { get; set; } = new();
    }
}
