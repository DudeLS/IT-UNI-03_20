using System;

using ITUniversity.Tasks.Enums;

namespace ITUniversity.Tasks.Entities
{
    /// <summary>
    /// Базовый класс задач
    /// </summary>
    public class TaskBase
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Тема
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public TaskStatus Status { get; set; }
    }
}