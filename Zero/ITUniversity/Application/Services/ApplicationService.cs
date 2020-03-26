using ITUniversity.Runtime.Session;

namespace ITUniversity.Application.Services
{
    /// <summary>
    /// Базовая реализация для всех сервисов приложения
    /// </summary>
    public abstract class ApplicationService : IApplicationService
    {
        public static string[] CommonPostfixes = { "AppService", "ApplicationService" };

        public ApplicationService(IAppSession session)
        {
            AppSession = session;
        }

        public IAppSession AppSession { get; }
    }
}