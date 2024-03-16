namespace Donik.Options
{
    /// <summary>
    /// Базовые настройки
    /// </summary>
    public abstract class OptionsBase
    {
        /// <summary>
        /// Название секции
        /// </summary>
        public abstract string SectionName { get; }
    }
}