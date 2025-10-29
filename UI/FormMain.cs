using LexicalAnalysis;
using Parsing;

namespace UI
{
    public partial class FormMain : Form
    {
        private readonly Parser parser = new();

        public FormMain()
        {
            InitializeComponent();
        }

        // Обработчик события нажатия кнопки "Анализировать текст".
        private void buttonAnalyze_Click(object sender, EventArgs e)
        {
            // Очищаем поле сообщений.
            richTextBoxMessages.Clear();

            // Передаем синтаксическому анализатору на анализ введённый текст.
            parser.Text = richTextBoxInput.Text;

            // Процесс синтаксического анализа должен быть обернут в "try...catch",
            // поскольку синтаксический анализатор при обнаружении ошибки в тексте генерирует исключительную ситуацию.
            try
            {
                parser.ParseText(); // Производим синтаксический (и лексический, естественно, тоже) анализ текста.

                richTextBoxMessages.AppendText("Текст правильный"); // Если дошли до сюда, то в тексте не было ошибок. Сообщаем об этом.
            }
            catch (SynAnException synAnException)
            {
                // В тексте была обнаружена синтаксическая ошибка.

                // Добавляем описание ошибки в поле сообщений.
                richTextBoxMessages.AppendText(String.Format("Синтаксическая ошибка ({0},{1}): {2}", synAnException.LineIndex + 1, synAnException.SymIndex + 1, synAnException.Message));

                // Располагаем курсор в исходном тексте на позиции ошибки.
                LocateCursorAtErrorPosition(synAnException.LineIndex, synAnException.SymIndex);
            }
            catch (LexAnException lexAnException)
            {
                // В тексте была обнаружена лексическая ошибка.

                // Добавляем описание ошибки в поле сообщений.
                richTextBoxMessages.AppendText(String.Format("Лексическая ошибка ({0},{1}): {2}", lexAnException.LineIndex + 1, lexAnException.SymStartIndex + 1, lexAnException.Message));

                // Располагаем курсор в исходном тексте на позиции ошибки.
                LocateCursorAtErrorPosition(lexAnException.LineIndex, lexAnException.SymStartIndex);
            }
        }

        // Расположить курсор в исходном тексте на позиции ошибки.
        private void LocateCursorAtErrorPosition(int lineIndex, int symIndex)
        {
            int k = 0;

            // Подсчитываем суммарное количество символов во всех строках до lineIndex.
            for (int i = 0; i < lineIndex; i++)
            {
                k += richTextBoxInput.Lines[i].Length + 1;
            }

            // Прибавляем символы из строки lineIndex.
            k += symIndex;

            // Располагаем курсор на вычисленной позиции.
            richTextBoxInput.Select();
            richTextBoxInput.Select(k, 1);
        }
    }
}
