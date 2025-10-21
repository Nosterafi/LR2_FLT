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
    private readonly HashSet<char> validLetters = ['a', 'b', 'c', 'd'];
    private readonly HashSet<char> validDigits = ['0', '1'];

    /// <summary>
    /// Символьное значение.
    /// </summary>
    private readonly char value;

    /// <summary>
    /// Тип символа согласно классификации.
    /// </summary>
    private readonly LetterType type;

    /// <summary>
    /// Строковое представление символа.
    /// </summary>
    public string Value => value.ToString();

    /// <summary>
    /// Тип классифицированного символа.
    /// </summary>
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

    /// <summary>
    /// Определяет, равен ли текущий объект другому объекту.
    /// </summary>
    public override readonly bool Equals(object? obj)
    {
        if (obj is ClassifiedLetter other)
            return Type == other.Type && Value == other.Value;

        return false;
    }

    /// <summary>
    /// Возвращает хэш-код для текущего объекта.
    /// </summary>
    public override int GetHashCode() => HashCode.Combine(Type, Value);

    /// <summary>
    /// Возвращает строковое представление классифицированного символа.
    /// </summary>
    public override string ToString() => $"{Type.ToString()} {Value.ToString()}";

    /// <summary>
    /// Определяет, равны ли два экземпляра ClassifiedLetter.
    /// </summary>
    public static bool operator ==(ClassifiedLetter left, ClassifiedLetter right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// Определяет, не равны ли два экземпляра ClassifiedLetter.
    /// </summary>
    public static bool operator !=(ClassifiedLetter left, ClassifiedLetter right)
    {
        return !(left == right);
    }
}

