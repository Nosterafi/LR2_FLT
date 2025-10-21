namespace Transliteration;

/// <summary>
/// Реализация транслитератора для последовательного чтения и классификации символов из текста.
/// Обеспечивает посимвольный анализ текста с автоматическим переходом между строками.
/// </summary>
public class Transliterator : ITransliterator<ClassifiedLetter>
{
    private string text = string.Empty;
    private int actualIndex = 0;

    /// <summary>
    /// Текущий индекс строки в тексте (нумерация с 0).
    /// </summary>
    public int CurLineIndex { get; private set; } = 0;

    /// <summary>
    /// Текущий индекс символа в строке (нумерация с 0).
    /// </summary>
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
            CurLineIndex = 0;
            CurSumIndex = -1;
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

            //Для того, чтобы перед чтением первого новой строки CurSumIndex был равен -1
            //и в дальнейшем не заходил дальше прочитанного символа.
            CurSumIndex = -2;
        }

        // Обновляем позицию относительно строки, передвигаем указатель и возвращаем литер.
        CurSumIndex++;
        return new(text[actualIndex++]);
    }
}

