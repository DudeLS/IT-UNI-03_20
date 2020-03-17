using System.Diagnostics;

using ITUniversity.Tasks.Entities;
using ITUniversity.Tasks.Stores;
using ITUniversity.Tasks.Web.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ITUniversity.Tasks.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        private readonly ITaskStore taskStore;

        public HomeController(ILogger<HomeController> logger, ITaskStore taskStore)
        {
            this.logger = logger;
            this.taskStore = taskStore;
        }

        public IActionResult Index()
        {
            var a = taskStore.Save(new TaskBase { Subject = "Hello", Description = "Hello world!!!" });

            a.Subject = "New";
            var d = taskStore.Update(a);

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
