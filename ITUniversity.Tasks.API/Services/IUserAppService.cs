using ITUniversity.Application.Services;
using ITUniversity.Tasks.API.Services.Dto;

namespace ITUniversity.Tasks.API.Services
{
    /// <summary>
    /// Сервис для работы с пользователями
    /// </summary>
    public interface IUserAppService : IApplicationService
    {
        /// <summary>
        /// Создать пользователя
        /// </summary>
        /// <param name="dto"></param>
        UserDto Create(CreateUserDto dto);

        /// <summary>
        /// Получить пользователя
        /// </summary>
        /// <param name="login">Логин</param>
        UserDto Get(string login);

        /// <summary>
        /// Получить пользователя
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        UserDto Get(string login, string password);

        /// <summary>
        /// Проверить пароль
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="password">Пароль</param>
        bool IsValidPassword(UserDto dto, string password);
    }
}