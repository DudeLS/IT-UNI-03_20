using ITUniversity.Tasks.Managers;
using ITUniversity.Tasks.Stores;

using Microsoft.Extensions.DependencyInjection;

namespace ITUniversity.Tasks
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTaskCoreServices(this IServiceCollection services)
        {
            services.AddSingleton<ITaskStore, TaskMemoryStore>();
            services.AddTransient<ITaskManager, TaskManager>();

            return services;
        }
    }
}