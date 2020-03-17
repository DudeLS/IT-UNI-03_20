using ITUniversity.Tasks.Entities;

namespace ITUniversity.Tasks.Managers
{
    /// <inheritdoc/>
    public class TaskManager : ITaskManager
    {
        /// <inheritdoc/>
        public TaskBase Create(TaskBase task)
        {
            return task;
        }

        /// <inheritdoc/>
        public TaskBase Create(string subject)
        {
            return new TaskBase();
        }
    }
}