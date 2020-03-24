using System;

using ITUniversity.Tasks.Entities;
using ITUniversity.Tasks.Enums;

namespace ITUniversity.Tasks.API.Services.Dto
{
    /// <summary>
    /// ДТО для <see cref="TaskBase"/>
    /// </summary>
    public class TaskDto
    {
        /// <summary>
        /// Индентификатор
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

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreationDate
        {
            get;
            set;
        }

        /// <summary>
        /// Статус
        /// </summary>
        public TaskStatus Status
        {
            get;
            set;
        }
    }
}