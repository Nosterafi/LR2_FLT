namespace Parsing;

/// <summary>
/// Класс исключительных ситуаций синтаксического анализа.
/// </summary>
public class SynAnException : Exception
{
    // Позиция возникновения исключительной ситуации в анализируемом тексте.
    private int lineIndex; // Индекс строки.
    private int symIndex;  // Индекс символа.

    /// <summary>
    /// Индекс строки, где возникла исключительная ситуация - свойство только для чтения.
    /// </summary>
    public int LineIndex
    {
        get { return lineIndex; }
    }

    /// <summary>
    /// Индекс символа, на котором возникла исключительная ситуация - свойство только для чтения.
    /// </summary>
    public int SymIndex
    {
        get { return symIndex; }
    }

    /// <summary>
    /// Конструктор исключительной ситуации.
    /// </summary>
    public SynAnException(string message, int lineIndex, int symIndex)
        : base(message)
    {
        this.lineIndex = lineIndex;
        this.symIndex = symIndex;
    }
}
