namespace ITUniversity.Runtime.Session
{
    /// <summary>
    /// Определяет некоторую информацию о сеансе, которая может быть полезна для приложений
    /// </summary>
    public interface IAppSession
    {
        /// <summary>
        /// Логин текущего пользователя
        /// </summary>
        string UserLogin { get; }
    }
}