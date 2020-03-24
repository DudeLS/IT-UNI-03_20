namespace ITUniversity.Application.Services
{
    /// <summary>
    /// Базовая реализация для всех сервисов приложения
    /// </summary>
    public abstract class ApplicationService : IApplicationService
    {
        public static string[] CommonPostfixes = { "AppService", "ApplicationService" };
    }
}