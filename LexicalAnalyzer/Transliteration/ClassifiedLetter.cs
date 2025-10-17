namespace Transliteration;

/// <summary>
/// Представляет классифицированный символ с указанием его типа и значения.
/// Используется для передачи информации о символах в процессе лексического анализа.
/// </summary>
public readonly struct ClassifiedLetter : IClassifiedLetter
{
    // Символы начала и конца комментариев.
    private const char commentStart = '{';
    private const char commentEnd = '}';

    // Допустимые символы для классификации
    private readonly  HashSet<char> validLetters = ['a', 'b', 'c', 'd'];
    private readonly HashSet<char> validDigits = ['0', '1'];

    /// <summary>
    /// Символьное значение.
    /// </summary>
    private readonly char value;

    /// <summary>
    /// Тип символа согласно классификации.
    /// </summary>
    private readonly LetterType type;

    public string Value => value.ToString();

    public LetterType Type => type;

    /// <summary>
    /// Инициализирует новый экземпляр структуры как маркер конца текста.
    /// </summary>
    public ClassifiedLetter() => type = LetterType.EndOfText;

    /// <summary>
    /// Инициализирует новый экземпляр структуры с указанным символом и определяет его тип.
    /// </summary>
    public ClassifiedLetter(char value)
    {
        this.value = value;

        // Классификация символа по приоритету
        if (validLetters.Contains(value))
            type = LetterType.ValidLetter;
        else if (validDigits.Contains(value))
            type = LetterType.ValidDigit;
        else if (value == '\n')
            type = LetterType.EndOfLine;
        else if (value == ' ')
            type = LetterType.Space;
        else if (value == commentStart)
            type = LetterType.CommentStart;
        else if (value == commentEnd)
            type = LetterType.CommentEnd;
        else
            type = LetterType.Other;
    }

    public override readonly bool Equals(object? obj)
    {
        if (obj is ClassifiedLetter other)
            return Type == other.Type && Value == other.Value;

        return false;
    }

    public override int GetHashCode() => HashCode.Combine(Type, Value);

    public override string ToString() => $"{Type.ToString()} {Value.ToString()}";

    public static bool operator ==(ClassifiedLetter left, ClassifiedLetter right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(ClassifiedLetter left, ClassifiedLetter right)
    {
        return !(left == right);
    }
}

