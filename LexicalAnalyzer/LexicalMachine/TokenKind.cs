namespace LexicalMachine;

public enum TokenKind
{
    Number,     // Число.
    Identifier, // Идентификатор.
    EndOfText,  // Конец текста.
    Unknown     // Неизвестный.
};