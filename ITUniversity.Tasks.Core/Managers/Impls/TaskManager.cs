using System;
using System.Collections.Generic;
using System.Linq;
using ITUniversity.Runtime.Session;
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

        private readonly IUserRepository userRepository;

        private readonly IAppSession appSession;

        public TaskManager(ITaskRepository taskRepository, IUserRepository userRepository, IAppSession appSession)
        {
            this.appSession = appSession;
            this.taskRepository = taskRepository;
            this.userRepository = userRepository;
        }

        /// <inheritdoc/>
        public TaskBase Create(TaskBase task)
        {
            task.CreationDate = DateTime.Now;
            task.Status = Enums.TaskStatus.ToDo;
            task.CreationAuthor = userRepository.FirstOrDefault(user => user.Login == appSession.UserLogin);

            return taskRepository.Save(task);
        }

        /// <inheritdoc/>
        public TaskBase Create(string subject)
        {
            var task = new TaskBase { Subject = subject };
            return Create(task);
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
        public ICollection<TaskBase> GetIncoming(User user)
        {
            var tasks = taskRepository.GetAll().Where(task => task.Status == Enums.TaskStatus.ToDo && task.Executor == user);
            return tasks.ToList();
        }

        /// <inheritdoc/>
        public ICollection<TaskBase> GetOutgoing(User user)
        {
            var tasks = taskRepository.GetAll().Where(task => task.CreationAuthor == user);
            return tasks.ToList();
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