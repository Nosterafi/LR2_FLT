using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transliteration
{
    public enum LetterType
    {
        ValidLetter,    // Допустимая буква.
        ValidDigit,     // Допустимая цифра.
        Space,     // Пробел.
        CommentStart,   // Начало комментария.
        CommentEnd, // Конец комментария.
        Other,     // Другой.
        EndOfText,  // Конец текста.
        EndOfLine   // Конец строки.
    };
}
