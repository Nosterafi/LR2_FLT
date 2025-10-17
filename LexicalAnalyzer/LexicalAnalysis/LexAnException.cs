namespace LexicalAnalysis;

/// <summary>
/// Исключение, возникающее при ошибках лексического анализа.
/// Содержит информацию о позиции ошибки в анализируемом тексте.
/// </summary>
public class LexAnException : Exception
{
    private int lineIndex;
    private int symIndex;

    /// <summary>
    /// Индекс строки, в которой возникла ошибка.
    /// </summary>
    /// <value>Номер строки (начиная с 0), где произошла ошибка.</value>
    public int LineIndex => lineIndex;

    /// <summary>
    /// Индекс символа в строке, где возникла ошибка.
    /// </summary>
    public int SymIndex => symIndex;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="LexAnException"/>.
    /// </summary>
    public LexAnException(string message, int lineIndex, int symIndex) : base(message)
    {
        this.lineIndex = lineIndex;
        this.symIndex = symIndex;
    }
}
