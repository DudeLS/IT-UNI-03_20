using System;
using System.Collections.Generic;
using System.Linq;

using ITUniversity.Tasks.Entities;
using ITUniversity.Tasks.Helpers;

namespace ITUniversity.Tasks.Stores
{
    /// <inheritdoc/>
    public class TaskMemoryStore : ITaskStore
    {
        private List<TaskBase> tasks;

        private long counter;

        /// <summary>
        /// Инициализировать экземпляр <see cref="TaskMemoryStore"/>
        /// </summary>
        public TaskMemoryStore()
        {
            counter = 1;
            tasks = new List<TaskBase>();
        }

        /// <inheritdoc/>
        public TaskBase Save(TaskBase task)
        {
            var saved = tasks.FirstOrDefault(item => item.CustomEquals(task));
            if (saved != null)
            {
                task.Id = saved.Id;
                return saved.Copy();
            }
            task.Id = counter++;
            tasks.Add(task.Copy());
            return task;
        }

        /// <inheritdoc/>
        public TaskBase Update(TaskBase task)
        {
            var saved = InternalGet(task.Id);
            if (saved == null)
            {
                throw new Exception("Задача не найдена");
            }
            saved.Subject = task.Subject;
            saved.Description = task.Description;
            //saved.CreationDate = task.CreationDate;
            saved.Status = task.Status;

            return task;
        }

        /// <inheritdoc/>
        public TaskBase Get(long id)
        {
            var saved = InternalGet(id);
            return saved?.Copy();
        }

        /// <inheritdoc/>
        public ICollection<TaskBase> GetAll()
        {
            return tasks.Select(task => task.Copy()).ToList();
        }

        /// <inheritdoc/>
        public void Delete(long id)
        {
            tasks.RemoveAll(task => task.Id == id);
        }

        private TaskBase InternalGet(long id)
        {
            return tasks.FirstOrDefault(task => task.Id == id);
        }
    }
}