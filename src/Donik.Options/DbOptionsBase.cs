namespace Donik.Options;

/// <summary>
/// Базовые настройки для базы данных
/// </summary>
public abstract class DbOptionsBase : OptionsBase
{
    /// <summary>
    /// Получить строку подключения
    /// </summary>
    /// <returns>Строка подключения</returns>
    public abstract string ToConnectionString();
}