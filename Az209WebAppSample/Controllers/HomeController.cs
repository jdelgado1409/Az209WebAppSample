using Az209WebAppSample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace Az209WebAppSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MySettings _mysettings;
        private readonly MyConnectionStrings _connectionStrings;

        public HomeController(ILogger<HomeController> logger, IOptions<MySettings> mySettings, IOptions<MyConnectionStrings> myConnectionStrings)
        {
            _logger = logger;
            _mysettings = mySettings.Value;
            _connectionStrings = myConnectionStrings.Value;
        }

        public IActionResult Index()
        {
            ViewBag.MyString = _mysettings.MyString;
            ViewBag.MySqlString = _connectionStrings.MYSQLCONNSTR_mysquielconst;
            return View();
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
    }
}