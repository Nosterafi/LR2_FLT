using LexicalMachine;

namespace LexicalAnalysis
{
    /// <summary>
    /// Представляет токен, распознанный лексическим анализатором.
    /// Содержит значение токена, его тип и позицию в исходном тексте.
    /// </summary>
    public class Token
    {
        /// <summary>
        /// Строковое значение токена.
        /// </summary>
        public readonly string Value;

        /// <summary>
        /// Тип токена согласно классификации.
        /// </summary>
        public readonly TokenKind Type;

        /// <summary>
        /// Индекс строки в исходном тексте, где начинается токен.
        /// </summary>
        /// <value>Номер строки (0-based), содержащей начало токена.</value>
        public readonly int LineIndex;

        /// <summary>
        /// Начальная позиция токена в строке.
        /// </summary>
        public readonly int SymStartIndex;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Token"/>.
        /// </summary>
        public Token(string value, TokenKind type, int lineIndex, int symStartIndex)
        {
            Value = value;
            Type = type;
            LineIndex = lineIndex;
            SymStartIndex = symStartIndex;
        }
    }
}