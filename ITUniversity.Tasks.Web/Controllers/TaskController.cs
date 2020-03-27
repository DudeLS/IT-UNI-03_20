using AutoMapper;

using ITUniversity.Tasks.API.Services;
using ITUniversity.Tasks.Web.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITUniversity.Tasks.Web.Controllers
{
    /// <summary>
    /// Контроллер для работы с задачами
    /// </summary>
    [Authorize(Roles = "user, admin")]
    public class TaskController : Controller
    {
        private readonly ITaskAppService taskAppService;

        private readonly IMapper mapper;

        /// <summary>
        /// Инициализировать экземпляр <see cref="TaskController"/>
        /// </summary>
        /// <param name="taskAppService">Сервис для работы с задачами</param>
        /// <param name="mapper">Маппер</param>
        public TaskController(ITaskAppService taskAppService, IMapper mapper)
        {
            this.taskAppService = taskAppService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Получить страницу со списком задач
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            var incoming = taskAppService.GetMyIncoming();
            var outgoing = taskAppService.GetMyOutgoing();
            return View(new TasksModel { Incoming = incoming, Outgoing = outgoing });
        }

        /// <summary>
        /// Получить страницу добавления задачи
        /// </summary>
        [HttpGet]
        public IActionResult Add()
        {
            return View(TaskCreateModel.New);
        }

        /// <summary>
        /// Удалить задачу
        /// </summary>
        /// <param name="id">Идентификатор задачи</param>
        [HttpPost]
        public IActionResult Delete(long id)
        {
            taskAppService.Delete(id);

            return Json(new { success = true });
        }

        /// <summary>
        /// Получить страницу с описанием задачи
        /// </summary>
        /// <param name="id">Идентификатор задачи</param>
        [HttpGet]
        public IActionResult Details(long id)
        {
            var dto = taskAppService.Get(id);

            return View(dto);
        }

        /// <summary>
        /// Получить стрицу редактирования задачи
        /// </summary>
        /// <param name="id">Идентификатор задачи</param>
        [HttpGet]
        public IActionResult Edit(long id)
        {
            var taskDto = taskAppService.Get(id);
            var model = mapper.Map<TaskEditModel>(taskDto);

            return View(model);
        }
    }
}