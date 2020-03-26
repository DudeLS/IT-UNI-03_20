using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

using AutoMapper;

using ITUniversity.Tasks.API.Services;
using ITUniversity.Tasks.API.Services.Dto;
using ITUniversity.Tasks.Web.Models.Account;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace ITUniversity.Tasks.Web.Controllers
{
    /// <summary>
    /// Контроллер для работы с аккаунтом пользователя
    /// </summary>
    public class AccountController : Controller
    {
        private readonly IUserAppService userAppService;

        private readonly IMapper mapper;

        /// <summary>
        /// Инициализировать экземпляр <see cref="AccountController"/>
        /// </summary>
        /// <param name="userAppService">Сервис для работы с пользователями</param>
        /// <param name="mapper">Маппер</param>
        public AccountController(IUserAppService userAppService, IMapper mapper)
        {
            this.userAppService = userAppService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Получить страницу логина
        /// </summary>
        [HttpGet]
        public IActionResult Login()
        {
            return View(LoginModel.New);
        }

        /// <summary>
        /// Выполнить логин пользователя
        /// </summary>
        /// <param name="model">Данные для логина</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = userAppService.Get(model.Login, model.Password);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Некорректные логин и(или) пароль");
                return View(model);
            }

            await Authenticate(user);

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Получить страницу регистрации
        /// </summary>
        [HttpGet]
        public IActionResult Register()
        {
            return View(RegisterModel.New);
        }

        /// <summary>
        /// Выполнить регистрацию нового пользователя
        /// </summary>
        /// <param name="model">Данные для регистрации</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var isFree = await userAppService.FreeLogin(model.Login);
            if (isFree)
            {
                var dto = mapper.Map<CreateUserDto>(model);
                var userDto = userAppService.Create(dto);

                await Authenticate(userDto);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Такой пользователь существует");
                return View(model);
            }
        }

        /// <summary>
        /// Выполнить выход из системы
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Account");
        }

        private async Task Authenticate(UserDto user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role != null ? user.Role.Name : string.Empty)
            };

            var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}