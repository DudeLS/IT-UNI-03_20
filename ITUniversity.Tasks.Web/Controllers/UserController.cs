using ITUniversity.Tasks.API.Services;

using Microsoft.AspNetCore.Mvc;

namespace ITUniversity.Tasks.Web.Controllers
{
    /// <summary>
    /// Контроллер для работы с пользователями
    /// </summary>
    public class UserController : Controller
    {
        private readonly IUserAppService userAppService;

        /// <summary>
        /// Инициализировать экземпляр <see cref="UserController"/>
        /// </summary>
        /// <param name="userAppService">Сервис для работы с пользователями</param>
        public UserController(IUserAppService userAppService)
        {
            this.userAppService = userAppService;
        }

        /// <summary>
        /// Получить страницу с пользователми
        /// </summary>
        public IActionResult Index()
        {
            var dtos = userAppService.GetAll();
            return View(dtos);
        }
    }
}