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
            var services = GetServices();

            var homeViewModel = new HomeViewModel
            {
                // ambil 3 layanan teratas untuk ditampilkan di Home
                FeaturedServices = services.Take(3).ToList()
            };

            return View(homeViewModel);
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
            var model = new PortfolioViewModel
            {
                Items = new List<PortfolioItem>
        {
            new PortfolioItem
            {
                Title = "Website Company Profile Pabrik Manufaktur",
                Category = "Website",
                Description = "Website company profile dengan halaman produk, sertifikasi, dan form permintaan penawaran yang terhubung ke tim sales.",
                TechStack = "ASP.NET Core, Bootstrap, SQL Server",
                Note = "Client industri manufaktur (B2B)"
            },
            new PortfolioItem
            {
                Title = "Sistem QC & Label Printing",
                Category = "Dashboard",
                Description = "Aplikasi internal untuk mencetak label QC, tracking produksi, dan log aktivitas user di lantai produksi.",
                TechStack = "ASP.NET Core, MySQL",
                Note = "Digunakan oleh tim QC & produksi"
            },
            new PortfolioItem
            {
                Title = "Monitoring Suhu & Timer Mesin",
                Category = "IoT",
                Description = "ESP32 + web dashboard untuk memantau suhu proses dan durasi siklus, dilengkapi notifikasi jika melewati batas.",
                TechStack = "ESP32, Web API, Web Dashboard",
                Note = "Integrasi dengan mesin existing"
            },
            new PortfolioItem
            {
                Title = "Dashboard Produksi Harian",
                Category = "Dashboard",
                Description = "Dashboard untuk menampilkan output produksi harian, downtime, dan efisiensi per mesin.",
                TechStack = "ASP.NET Core, Chart library",
                Note = "Internal project"
            },
            new PortfolioItem
            {
                Title = "Integrasi PLC ke Database",
                Category = "PLC & Automation",
                Description = "Integrasi data dari PLC ke database untuk monitoring dan pencatatan histori proses.",
                TechStack = "PLC, OPC / Modbus, Database",
                Note = "Integrasi ke sistem laporan harian"
            }
        }
            };

            return View(model);
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
        new ServiceItem
        {
            Title = "Custom Software Development",
            Description = "Pengembangan aplikasi khusus: integrasi API, otomasi pekerjaan manual, atau sistem internal custom.",
            BadgeText = "Custom",
            BadgeCss = "bg-info-subtle border border-info text-info"
        }
    };
        }


    }



}
