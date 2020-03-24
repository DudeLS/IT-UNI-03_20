using ITUniversity.AspNetCore;
using ITUniversity.Tasks.API;
using ITUniversity.Tasks.API.Services;
using ITUniversity.Tasks.API.Services.Imps;
using ITUniversity.Tasks.Managers;
using ITUniversity.Tasks.NHibernate;
using ITUniversity.Tasks.NHibernate.Repositories;
using ITUniversity.Tasks.Repositories;

using Microsoft.Extensions.DependencyInjection;

using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;

namespace ITUniversity.Tasks.Web
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTaskCore(this IServiceCollection services)
        {
            services.AddTransient<ITaskManager, TaskManager>();

            return services;
        }

        public static IServiceCollection AddTaskApplication(this IServiceCollection services)
        {
            services.CreateControllersForAppServices(typeof(TaskApplicationModule).Assembly);
            services.AddTransient<ITaskAppService, TaskAppService>();

            return services;
        }

        public static IServiceCollection AddTaskNHibernate(this IServiceCollection services, string connectionString)
        {
            var mapper = new ModelMapper();
            mapper.AddMappings(typeof(TaskNHibernateModule).Assembly.ExportedTypes);
            var mappings = mapper.CompileMappingForAllExplicitlyAddedEntities();

            var configuration = new Configuration();
            configuration.DataBaseIntegration(c =>
            {
                c.Dialect<MsSql2012Dialect>();
                c.ConnectionString = connectionString;
                //c.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                //c.SchemaAction = SchemaAutoAction.Validate;
                //c.LogFormattedSql = true;
                //c.LogSqlInConsole = true;
            });
            configuration.AddMapping(mappings);

            var sessionFactory = configuration.BuildSessionFactory();

            services.AddSingleton(sessionFactory);
            services.AddScoped(factory => sessionFactory.OpenSession());
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}