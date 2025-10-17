namespace Transliteration;

/// <summary>
/// Реализация транслитератора для последовательного чтения и классификации символов из текста.
/// Обеспечивает посимвольный анализ текста с автоматическим переходом между строками.
/// </summary>
public class Transliterator : ITransliterator<ClassifiedLetter>
{
    private string text = string.Empty;
    private int actualIndex = 0;

    public int CurLineIndex { get; private set; } = 0;

    public int CurSumIndex { get; private set; } = -1;

    /// <summary>
    /// Устанавливает текст для анализа и сбрасывает текущую позицию чтения в начало.
    /// </summary>
    public string Text
    {
        set
        {
            // Сбрасываем позицию чтения при установке нового текста
            text = value ?? throw new ArgumentNullException(nameof(value));
            actualIndex = 0;
        }
    }

    /// <summary>
    /// Возвращает следующий классифицированный символ из текста.
    /// При достижении конца текста возвращает символ с типом <see cref="LetterType.EndOfText"/>.
    /// </summary>
    public ClassifiedLetter GetNextLetter()
    {
        // Проверяем, достигли ли конца текста
        if (actualIndex >= text.Length)
            return new(); // Возвращаем маркер конца текста

        if (text[actualIndex] == '\n')
        {
            CurLineIndex++;
            CurSumIndex = -1;
        }

        // Обновляем позицию относительно строки, передвигаем указатель и возвращаем литер.
        CurSumIndex++;
        return new(text[actualIndex++]);
    }
}

