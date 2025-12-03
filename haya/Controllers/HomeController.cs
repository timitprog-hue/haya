using haya.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace haya.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // --- Services section (ambil dari GetServices()) ---
            var services = GetServices(); // sudah ada di controller kamu

            var servicesVm = new ServicesViewModel
            {
                Services = services.ToList(),
                Industries = new List<string>
        {
            "Manufaktur",
            "QC & Produksi",
            "Warehouse / Gudang",
            "Distribusi & Logistik",
            "Perkantoran & Jasa"
        }
            };

            // --- Home section (yang sebelumnya FeaturedServices) ---
            var homeVm = new HomeViewModel
            {
                FeaturedServices = services.Take(3).ToList()
            };

            // --- Portfolio dummy (bisa kamu ganti nanti) ---
            var portfolioVm = new PortfolioViewModel
            {
                Items = new List<PortfolioItem>
        {
            new PortfolioItem
            {
                Title = "Website Company Profile Pabrik Manufaktur",
                Category = "Website",
                Description = "Website dengan halaman produk, sertifikasi, dan form penawaran.",
                TechStack = "ASP.NET Core, Bootstrap",
                Note = "Client industri manufaktur"
            },
            new PortfolioItem
            {
                Title = "Sistem QC & Label Printing",
                Category = "Dashboard",
                Description = "Aplikasi internal untuk QC label, tracking, dan activity log.",
                TechStack = "ASP.NET Core, MySQL",
                Note = "Dipakai tim QC & Produksi"
            },
            new PortfolioItem
            {
                Title = "Monitoring Suhu & Timer Mesin",
                Category = "IoT",
                Description = "ESP32 + web dashboard untuk monitoring suhu & timer.",
                TechStack = "ESP32, Web API",
                Note = "Integrasi mesin existing"
            }
        }
            };

            // --- Gabungkan semua ke dalam HomePageViewModel ---
            var pageVm = new HomePageViewModel
            {
                Home = homeVm,
                Services = servicesVm,
                Portfolio = portfolioVm
            };

            return View(pageVm);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult About()
        {
            ViewData["Title"] = "Tentang Kami";
            return View();
        }

        public IActionResult Services()
        {
            var services = GetServices();

            var industries = new List<string>
    {
        "Manufaktur & Pabrik",
        "Distribusi & Warehouse",
        "QC & Laboratorium",
        "Perkantoran & Corporate",
        "Logistik & Operasional",
        "Engineering & Teknis"
    };

            var viewModel = new ServicesViewModel
            {
                Services = services,
                Industries = industries
            };

            return View(viewModel);
        }

        public IActionResult Portfolio()
        {
            return View();
        }


        public IActionResult Contact()
        {
            ViewData["Title"] = "Kontak Kami";
            return View();
        }
        private List<ServiceItem> GetServices()
        {
            return new List<ServiceItem>
    {
        new ServiceItem
        {
            Title = "Website Company Profile",
            Description = "Pembuatan website profesional sebagai representasi digital perusahaan Anda. Modern, cepat, dan SEO-friendly.",
            BadgeText = "Branding",
            BadgeCss = "bg-primary-subtle border border-primary text-primary"
        },
        new ServiceItem
        {
            Title = "Aplikasi Web & Dashboard",
            Description = "Sistem internal seperti absensi, QC, produksi, gudang, inventori, hingga dashboard analitik real-time.",
            BadgeText = "Efficiency",
            BadgeCss = "bg-success-subtle border border-success text-success"
        },
        new ServiceItem
        {
            Title = "Pemrograman Mesin Industri",
            Description = "Integrasi software dengan mesin pabrik, pengendalian motor, sensor, dan otomatisasi proses industri.",
            BadgeText = "Industrial",
            BadgeCss = "bg-warning-subtle border border-warning text-warning"
        },
        new ServiceItem
        {
            Title = "PLC Programming & Automation",
            Description = "Konfigurasi dan pemrograman PLC (Mitsubishi, Omron, Siemens), HMI, troubleshooting, dan integrasi mesin industri.",
            BadgeText = "Automation",
            BadgeCss = "bg-danger-subtle border border-danger text-danger"
        },
        new ServiceItem
        {
            Title = "IoT Development",
            Description = "Pengembangan sistem IoT berbasis ESP32, Arduino, Raspberry Pi untuk monitoring suhu, mesin, timer, hingga alert sistem.",
            BadgeText = "Industry 4.0",
            BadgeCss = "bg-secondary-subtle border border-secondary text-secondary"
        },
    };

        }


    }



}
