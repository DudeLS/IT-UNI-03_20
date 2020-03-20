using ITUniversity.AspNetCore;
using ITUniversity.Tasks.API;
using ITUniversity.Tasks.API.Services;
using ITUniversity.Tasks.API.Services.Imps;
using ITUniversity.Tasks.Managers;
using ITUniversity.Tasks.Stores;

using Microsoft.Extensions.DependencyInjection;

namespace ITUniversity.Tasks.Web
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTaskCoreServices(this IServiceCollection services)
        {
            services.AddSingleton<ITaskStore, TaskMemoryStore>();
            services.AddTransient<ITaskManager, TaskManager>();

            return services;
        }

        public static IServiceCollection AddTaskApplicationServices(this IServiceCollection services)
        {
            services.CreateControllersForAppServices(typeof(TaskAPIModule).Assembly);
            services.AddTransient<ITaskAppService, TaskAppService>();

            return services;
        }
    }
}