using System;
using System.ComponentModel;

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
        [DisplayName("Описание")]
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Исполнитель
        /// </summary>
        [DisplayName("Исполнитель")]
        public int? Executor
        {
            get;
            set;
        }
    }
}