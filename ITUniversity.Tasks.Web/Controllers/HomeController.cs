using System.Diagnostics;

using ITUniversity.Tasks.Entities;
using ITUniversity.Tasks.Managers;
using ITUniversity.Tasks.Web.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ITUniversity.Tasks.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        private readonly ITaskManager taskManager;

        public HomeController(ILogger<HomeController> logger, ITaskManager taskManager)
        {
            this.logger = logger;
            this.taskManager = taskManager;
        }

        public IActionResult Index()
        {
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
