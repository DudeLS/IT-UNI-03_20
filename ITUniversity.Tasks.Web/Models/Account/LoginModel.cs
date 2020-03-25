using System.ComponentModel.DataAnnotations;

namespace ITUniversity.Tasks.Web.Models.Account
{
    /// <summary>
    /// Модель логина пользователя
    /// </summary>
    public class LoginModel
    {
        public static LoginModel New
        {
            get { return new LoginModel(); }
        }

        /// <summary>
        /// Логин
        /// </summary>
        [Required(ErrorMessage = "Не указан логин")]
        public string Login
        {
            get;
            set;
        }

        /// <summary>
        /// Пароль
        /// </summary>
        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password
        {
            get;
            set;
        }
    }
}