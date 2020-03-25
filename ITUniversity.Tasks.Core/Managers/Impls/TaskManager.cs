using System;
using System.Collections.Generic;

using ITUniversity.Tasks.Entities;
using ITUniversity.Tasks.Repositories;

namespace ITUniversity.Tasks.Managers.Impls
{
    /// <summary>
    /// Менеджер сущности <see cref="TaskBase"/>
    /// </summary>
    public class TaskManager : ITaskManager
    {
        private readonly ITaskRepository taskRepository;

        public TaskManager(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        /// <inheritdoc/>
        public TaskBase Create(TaskBase task)
        {
            task.CreationDate = DateTime.Now;
            task.Status = Enums.TaskStatus.ToDo;

            return taskRepository.Save(task);
        }

        /// <inheritdoc/>
        public TaskBase Create(string subject)
        {
            var task = new TaskBase { Subject = subject };
            return taskRepository.Save(task);
        }

        /// <inheritdoc/>
        public TaskBase Get(long id)
        {
            return taskRepository.Get(id);
        }

        /// <inheritdoc/>
        public ICollection<TaskBase> GetAll()
        {
            return taskRepository.GetAllList();
        }

        /// <inheritdoc/>
        public TaskBase Update(TaskBase task)
        {
            return taskRepository.Update(task);
        }

        /// <inheritdoc/>
        public void Delete(long id)
        {
            taskRepository.Delete(id);
        }
    }
}