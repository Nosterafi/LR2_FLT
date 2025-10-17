using Transliteration;

namespace LexicalMachine;

/// <summary>
/// Представляет состояние конечного автомата в лексическом анализаторе.
/// Содержит набор правил перехода и флаг, указывающий, является ли состояние принимающим.
/// </summary>
public class State
{
    /// <summary>
    /// Название состояния для идентификации и отладки.
    /// </summary>
    public readonly string Name;

    /// <summary>
    /// Набор правил перехода из данного состояния.
    /// </summary>
    public readonly Dictionary<IClassifiedLetter, State> Rules = [];

    /// <summary>
    /// Указывает, является ли состояние принимающим (конечным).
    /// </summary>
    public bool IsAccepting { get; set; }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="State"/>.
    /// </summary>
    public State(string name, bool isAccepting = false)
    {
        ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));

        Name = name;
        IsAccepting = isAccepting;
    }
}
