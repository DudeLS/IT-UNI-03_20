using ITUniversity.Tasks.Entities;
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
            return View(tasks);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new TaskBase());
        }

        [HttpPost]
        public IActionResult Create(TaskBase task)
        {
            taskManager.Create(task);
            return RedirectToAction("Index");
        }
    }
}