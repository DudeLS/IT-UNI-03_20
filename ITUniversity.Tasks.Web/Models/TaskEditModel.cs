namespace ITUniversity.Tasks.Web.Models
{
    /// <summary>
    /// Модель редактирования задачи
    /// </summary>
    public class TaskEditModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id
        {
            get;
            set;
        }

        /// <summary>
        /// Тема
        /// </summary>
        public string Subject
        {
            get;
            set;
        }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description
        {
            get;
            set;
        }
    }
}