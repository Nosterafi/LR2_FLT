namespace Parsing;

/// <summary>
/// Интерфейс для синтаксического анализатора.
/// </summary>
public interface IParser
{
    /// <summary>
    /// Текст для проверки.
    /// </summary>
    string Text { set; }

    /// <summary>
    /// Проверяет текст на корректность.
    /// Правила проверки определяются конкретной реализацией.
    /// </summary>
    void ParseText();
}
