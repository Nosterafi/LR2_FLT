using LexicalMachine;

namespace LexicalAnalysis
{
    /// <summary>
    /// Интерфейс лексического анализатора.
    /// </summary>
    public interface ILexicalAnalizer
    {
        /// <summary>
        /// Проверяемый текст.
        /// </summary>
        string Text { set; }

        /// <summary>
        /// Набор конечных автоматов для получения токенов.
        /// </summary>
        List<StateMachine> Machines { get; }

        /// <summary>
        /// Получает следующий токен из заданного текста.
        /// </summary>
        Token GetNextToken();
    }
}
