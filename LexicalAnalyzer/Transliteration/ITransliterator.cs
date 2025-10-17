namespace Transliteration;

/// <summary>
/// Интерфейс для транслитераторов, обеспечивающих последовательное чтение и классификацию символов текста.
/// Определяет контракт для классов, реализующих посимвольный анализ текста.
/// </summary>
public interface ITransliterator<TLiter> where TLiter : IClassifiedLetter
{
    /// <summary>
    /// Возвращает номер анализируемой строки.
    /// </summary>
    int CurLineIndex { get; }

    /// <summary>
    /// Возвращает номер текущего символа в строке.
    /// </summary>
    int CurSumIndex { get; }

    /// <summary>
    /// Устанавливает текст для последующего посимвольного анализа.
    /// При установке нового текста состояние анализатора должно сбрасываться.
    /// </summary>
    string Text { set; }

    /// <summary>
    /// Возвращает следующий классифицированный символ из установленного текста.
    /// </summary>
    TLiter GetNextLetter();
}