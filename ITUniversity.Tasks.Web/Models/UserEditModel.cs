namespace ITUniversity.Tasks.Web.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class UserEditModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Логин
        /// </summary>
        public string Login
        {
            get;
            set;
        }

        /// <summary>
        /// Почта
        /// </summary>
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// Роль
        /// </summary>
        public int RoleId
        {
            get;
            set;
        }
    }
}