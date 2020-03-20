using ITUniversity.AspNetCore;
using ITUniversity.Tasks.Application;
using ITUniversity.Tasks.Application.Services;
using ITUniversity.Tasks.Application.Services.Imps;
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
            services.CreateControllersForAppServices(typeof(TaskApplicationModule).Assembly);
            services.AddTransient<ITaskAppService, TaskAppService>();

            return services;
        }
    }
}