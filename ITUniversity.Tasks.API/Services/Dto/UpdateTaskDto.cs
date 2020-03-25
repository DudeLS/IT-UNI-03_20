using ITUniversity.Tasks.Entities;
using ITUniversity.Tasks.Enums;

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
        /// Статус
        /// </summary>
        public TaskStatus Status
        {
            get;
            set;
        }
    }
}