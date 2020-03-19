using AutoMapper;

using ITUniversity.Tasks.Entities;
using ITUniversity.Tasks.Managers;
using ITUniversity.Tasks.Web.Models;

using Microsoft.AspNetCore.Mvc;

namespace ITUniversity.Tasks.Web.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskManager taskManager;
        private readonly IMapper mapper;

        public TaskController(ITaskManager taskManager, IMapper mapper)
        {
            this.taskManager = taskManager;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var tasks = taskManager.GetAll();
            return View(tasks);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(TaskCreateModel.New);
        }

        [HttpPost]
        public IActionResult Create(TaskCreateModel task)
        {
            if (!ModelState.IsValid)
            {
                return View(task);
            }
            var entity = mapper.Map<TaskBase>(task);
            taskManager.Create(entity);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {
            taskManager.Delete(id);

            return Json(new { success = true });
        }
    }
}