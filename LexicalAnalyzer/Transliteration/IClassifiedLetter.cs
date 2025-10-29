namespace Transliteration
{
    /// <summary>
    /// Интерфейс, определяющий свойства для класса классифицированного литера.
    /// </summary>
    public interface IClassifiedLetter
    {
        /// <summary>
        /// Символы, которыми данный литер представлен в тексте.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Тип литера.
        /// </summary>
        public LetterType Type { get; }
    }
}
