using Transliteration;

namespace LexicalMachine;

/// <summary>
/// Представляет конфигурацию конечного автомата для распознавания определенного типа токенов.
/// Содержит начальное состояние, тип токена и условие applicability автомата.
/// </summary>
public class StateMachine
{
    /// <summary>
    /// Классифицированные символы, для которых применим данный автомат.
    /// </summary>
    private readonly HashSet<IClassifiedLetter> applicableLetters;

    /// <summary>
    /// Начальное состояние конечного автомата.
    /// </summary>
    public readonly State InitialState;

    /// <summary>
    /// Тип токена, который распознает данный автомат.
    /// </summary>
    public readonly TokenKind TokenType;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="StateMachine"/>.
    /// </summary>
    public StateMachine(State initialState, TokenKind tokenType, HashSet<IClassifiedLetter> applicableLetters)
    {
        ArgumentNullException.ThrowIfNull(initialState, nameof(initialState));
        ArgumentNullException.ThrowIfNull(applicableLetters, nameof(applicableLetters));

        TokenType = tokenType;
        InitialState = initialState;
        this.applicableLetters = applicableLetters;
    }

    /// <summary>
    /// Проверяет, применим ли данный автомат к переданному символу.
    /// </summary>
    public bool IsApplicated(IClassifiedLetter letter) =>
        applicableLetters.Contains(letter);
}