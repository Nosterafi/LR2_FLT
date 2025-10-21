using LexicalAnalysis;
using LexicalMachine;

namespace Parsing;

/// <summary>
/// Синтаксический анализатор, реализующий рекурсивный спуск для грамматики языка.
/// </summary>
public class Parser : IParser
{
    private readonly ILexicalAnalizer lexicalAnalizer = AnalyzerCreator.Create(string.Empty);
    private Token curToken = new(string.Empty, TokenKind.Unknown, 0, 0);

    /// <summary>
    /// Устанавливает исходный текст для синтаксического анализа.
    /// </summary>
    public string Text
    {
        set => lexicalAnalizer.Text = value;
    }

    /// <summary>
    /// Выполняет синтаксический анализ установленного текста.
    /// </summary>
    public void ParseText() => S();

    /// <summary>
    /// Метод для нетерминала S.
    /// </summary>
    private void S()
    {
        ReadNextToken();
        B();
        ReadNextToken();
        B();
        ReadNextToken();
        SPrime();
    }

    /// <summary>
    /// Метод для нетерминала S'.
    /// </summary>
    private void SPrime()
    {
        if (curToken.Type == TokenKind.EndOfText)
            return;

        A();
        ReadNextToken();
        SPrime();
    }

    /// <summary>
    /// Метод для нетерминала A.
    /// </summary>
    private void A()
    {
        if (curToken.Type == TokenKind.Number)
            return;

        if (curToken.Type == TokenKind.Identifier)
        {
            ReadNextToken();
            A();
            ReadNextToken();
            A();
        }
        else ThrowSyntaxError("Ожидалось слово из букв.");
    }

    /// <summary>
    /// Метод для нетерминала B.
    /// </summary>
    private void B()
    {
        if (curToken.Type == TokenKind.Identifier)
            return;
        else ThrowSyntaxError("Ожидалось слово из букв");
    }

    /// <summary>
    /// Читает следующий токен из лексического анализатора.
    /// </summary>
    private void ReadNextToken() =>
        curToken = lexicalAnalizer.GetNextToken();

    /// <summary>
    /// Генерирует исключение синтаксической ошибки с указанием позиции в тексте.
    /// </summary>
    private void ThrowSyntaxError(string message) =>
        throw new SynAnException(
            message,
            curToken.LineIndex + 1,
            curToken.SymStartIndex + 1);
}
