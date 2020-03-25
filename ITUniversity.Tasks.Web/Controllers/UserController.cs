using ITUniversity.Tasks.API.Services;

using Microsoft.AspNetCore.Mvc;

namespace ITUniversity.Tasks.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserAppService userAppService;

        public UserController(IUserAppService userAppService)
        {
            this.userAppService = userAppService;
        }

        public IActionResult Index()
        {
            var dtos = userAppService.GetAll();
            return View(dtos);
        }
    }
}