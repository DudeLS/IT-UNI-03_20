using ITUniversity.Tasks.Entities;

namespace ITUniversity.Tasks.Helpers
{
    public static class TaskHelper
    {
        public static bool CustomEquals(this TaskBase thisTask, TaskBase otherTask)
        {
            return thisTask.Subject == otherTask.Subject
                && thisTask.Description == otherTask.Description
                && thisTask.CreationDate == otherTask.CreationDate
                && thisTask.Status == otherTask.Status;
        }

        public static TaskBase Copy(this TaskBase task)
        {
            return new TaskBase
            {
                Id = task.Id,
                Subject = task.Subject,
                Description = task.Description,
                CreationDate = task.CreationDate,
                Status = task.Status
            };
        }
    }
}