﻿using ITUniversity.Tasks.Entities;

namespace ITUniversity.Tasks.API.Services.Dto
{
    /// <summary>
    /// ДТО обновления <see cref="TaskBase"/>
    /// </summary>
    public class UpdateTaskDto
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
        /// Описание
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Исполнитель
        /// </summary>
        public int? Executor
        {
            get;
            set;
        }
    }
}