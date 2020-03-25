namespace ITUniversity.Tasks.API.Services.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateUserDto
    {
        /// <summary>
        /// Логин
        /// </summary>
        public virtual string Login
        {
            get;
            set;
        }

        /// <summary>
        /// Почта
        /// </summary>
        public virtual string Email
        {
            get;
            set;
        }

        /// <summary>
        /// Пароль
        /// </summary>
        public virtual string Password
        {
            get;
            set;
        }
    }
}