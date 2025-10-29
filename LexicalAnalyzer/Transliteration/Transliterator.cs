namespace Transliteration;

/// <summary>
/// Реализация транслитератора для последовательного чтения и классификации символов из текста.
/// Обеспечивает посимвольный анализ текста с автоматическим переходом между строками.
/// </summary>
public class Transliterator : ITransliterator<ClassifiedLetter>
{
    private string text = string.Empty;
    private int actualIndex;
    private bool transferFlag;

    /// <summary>
    /// Текущий индекс строки в тексте (нумерация с 0).
    /// </summary>
    public int CurLineIndex { get; private set; }

    /// <summary>
    /// Текущий индекс символа в строке (нумерация с 0).
    /// </summary>
    public int CurSumIndex { get; private set; }

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
            CurSumIndex = 0;
            
            transferFlag = false;
        }
    }

    /// <summary>
    /// Возвращает следующий классифицированный символ из текста.
    /// При достижении конца текста возвращает символ с типом <see cref="LetterType.EndOfText"/>.
    /// </summary>
    public ClassifiedLetter GetNextLetter()
    {
        // Если происходит переход на новую строку, то увеличиваем номер строки и обнуляем индекс относительно её
        if (transferFlag)
        {
            CurLineIndex++;
            CurSumIndex = -1;
            transferFlag = false;
        }

        // Проверяем, достигли ли конца текста
        if (actualIndex == text.Length)
        {
            CurSumIndex++;
            actualIndex++;
            return new(); // Возвращаем маркер конца текста
        }

        // При попытке получить символ после конца анализа возвращаем конец текста
        if (actualIndex > text.Length)
            return new();

        // Если встречен символ перехода на новую строку, указываем на необходимость перехода на новую строку
        // при следующем вызове
        if (text[actualIndex] == '\n')
            transferFlag = true;
        
        // Обновляем позицию относительно строки, передвигаем указатель и возвращаем литер
        // Если был совершён переход на новую строку, то увеличение CurSumIndex не требуется
        if (actualIndex > 0) CurSumIndex++;

        return new(text[actualIndex++]);
    }
}

