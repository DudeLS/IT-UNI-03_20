namespace ITUniversity.Tasks.API.Services.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateUserDto
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
        public int? RoleId
        {
            get;
            set;
        }
    }
}