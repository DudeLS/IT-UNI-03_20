using ITUniversity.Tasks.Managers;

using Microsoft.AspNetCore.Mvc;

namespace ITUniversity.Tasks.Web.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskManager taskManager;

        public TaskController(ITaskManager taskManager)
        {
            this.taskManager = taskManager;
        }

        public IActionResult Index()
        {
            var tasks = taskManager.GetAll();
            return View();
        }
    }
}