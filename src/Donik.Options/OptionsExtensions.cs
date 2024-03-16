using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Donik.Options;

/// <summary>
/// Расширение для настроек
/// </summary>
public static class OptionsExtensions
{
    /// <summary>
    /// Сконфигурировать и валидировать настройки
    /// </summary>
    /// <typeparam name="T">Тип настроек</typeparam>
    public static IServiceCollection ConfigureAndValidateOptions<T>(this IServiceCollection services)
        where T : OptionsBase
    {
        return services
            .AddOptions<T>()
            .BindConfiguration(GetSectionName<T>())
            .ValidateDataAnnotations()
            .ValidateOnStart()
            .Services
            .AddSingleton(provider => provider.GetOptions<T>());
    }

    /// <summary>
    /// Получить настройки
    /// </summary>
    /// <typeparam name="T">Тип настроек</typeparam>
    public static T GetOptions<T>(this IServiceCollection services)
        where T : OptionsBase
    {
        return services
            .BuildServiceProvider()
            .GetRequiredService<T>();
    }

    private static string GetSectionName<T>()
        where T : OptionsBase
    {
        return Activator
            .CreateInstance<T>()
            .SectionName;
    }

    private static T GetOptions<T>(this IServiceProvider provider)
        where T : OptionsBase
    {
        return provider
            .GetRequiredService<IOptions<T>>()
            .Value;
    }
}