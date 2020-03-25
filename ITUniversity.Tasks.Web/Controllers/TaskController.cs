using AutoMapper;

using ITUniversity.Tasks.API.Services;
using ITUniversity.Tasks.Web.Models;

using Microsoft.AspNetCore.Mvc;

namespace ITUniversity.Tasks.Web.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskAppService taskAppService;
        private readonly IMapper mapper;

        public TaskController(ITaskAppService taskAppService, IMapper mapper)
        {
            this.taskAppService = taskAppService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var tasks = taskAppService.GetAll();
            return View(tasks);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(TaskCreateModel.New);
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {
            taskAppService.Delete(id);

            return Json(new { success = true });
        }

        [HttpGet]
        public IActionResult Details(long id)
        {
            var task = taskAppService.Get(id);

            return View(task);
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            var task = taskAppService.Get(id);
            var model = mapper.Map<TaskEditModel>(task);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(TaskEditModel task)
        {
            //var entity = mapper.Map<TaskBase>(task);
            //taskAppService.Update(entity);

            return RedirectToAction("Index");
        }
    }
}