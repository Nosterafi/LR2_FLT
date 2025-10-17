using System.Text;
using Transliteration;
using LexicalMachine;

namespace LexicalAnalysis
{
    /// <summary>
    /// Лексический анализатор, выполняющий разбор исходного текста на токены с использованием конечных автоматов.
    /// </summary>
    public class LexicalAnalyzer
    {
        private readonly ITransliterator<ClassifiedLetter> transliterator = new Transliterator();
        private ClassifiedLetter curLetter;

        /// <summary>
        /// Список зарегистрированных конечных автоматов для распознавания токенов.
        /// </summary>
        public readonly List<StateMachine> Machines = new();

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="LexicalAnalyzer"/>.
        /// </summary>
        public LexicalAnalyzer(string text)
        {
            ArgumentNullException.ThrowIfNull(text, nameof(text));

            transliterator.Text = text;
            curLetter = transliterator.GetNextLetter();
        }

        /// <summary>
        /// Извлекает следующий токен из анализируемого текста.
        /// </summary>
        public Token GetNextToken()
        {
            SkipUnrelatedLetters();

            if (curLetter.Type == LetterType.EndOfText)
                return new(
                    default,
                    TokenKind.EndOfText,
                    transliterator.CurLineIndex,
                    transliterator.CurSumIndex);

            // Попытка применить каждый зарегистрированный автомат
            foreach (var machine in Machines)
                if (machine.IsApplicated(curLetter))
                {
                    var tokenLineIndex = transliterator.CurLineIndex;
                    var tokenSumIndex = transliterator.CurSumIndex;

                    var result = RunStateMachine(machine);
                    if (result.Success)
                        return new(
                            result.Buffer,
                            machine.TokenType,
                            tokenLineIndex,
                            tokenSumIndex);
                }

            throw new LexAnException($"Неверный символ '{curLetter.Value}'",
                transliterator.CurLineIndex,
                transliterator.CurSumIndex);
        }

        /// <summary>
        /// Выполняет запуск указанного конечного автомата для распознавания токена.
        /// </summary>
        private (bool Success, string Buffer) RunStateMachine(StateMachine machine)
        {
            if (machine.InitialState == null) 
                throw new NullReferenceException("");

            var buffer = new StringBuilder();
            var currentState = machine.InitialState;

            while (true)
            {
                var isSucces = currentState.Rules.TryGetValue(curLetter, out State nextState);
                if (!isSucces)
                    return (currentState.IsAccepting, buffer.ToString());

                buffer.Append(curLetter.Value);
                currentState = nextState;

                curLetter = transliterator.GetNextLetter();
            }
        }

        /// <summary>
        /// Пропускает незначащие символы (пробелы и комментарии).
        /// </summary>
        private void SkipUnrelatedLetters()
        {
            do
            {
                SkipSpaces();
                SkipComment();
                SkipEnters();
            }
            while (curLetter.Type == LetterType.Space || 
            curLetter.Type == LetterType.CommentStart ||
            curLetter.Type == LetterType.CommentEnd);
        }

        /// <summary>
        /// Пропускает последовательность пробельных символов.
        /// </summary>
        private void SkipSpaces()
        {
            while (curLetter.Type == LetterType.Space)
                curLetter = transliterator.GetNextLetter();
        }

        /// <summary>
        /// Пропускает содержимое комментария, ограниченное фигурными скобками.
        /// </summary>
        private void SkipComment()
        {
            if (curLetter.Type != LetterType.CommentStart)
                return;

            var beginLineIndex = transliterator.CurLineIndex;
            var beginSumIndex = transliterator.CurSumIndex;

            // Чтение содержимого комментария до закрывающей скобки
            while (curLetter.Type != LetterType.CommentEnd)
            {
                curLetter = transliterator.GetNextLetter();

                // Проверка незакрытого комментария в конце текста
                if (curLetter.Type == LetterType.EndOfText)
                    throw new LexAnException("Незакрытый комментарий", beginLineIndex, beginSumIndex);
            }

            // Пропуск закрывающей скобки комментария
            curLetter = transliterator.GetNextLetter();
        }

        /// <summary>
        /// Пропускает переходы на новую строку.
        /// </summary>
        private void SkipEnters()
        {
            while (curLetter.Type == LetterType.EndOfLine)
                transliterator.GetNextLetter();
        }
    }
}

