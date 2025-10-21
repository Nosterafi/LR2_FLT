using LexicalAnalysis;
using Parsing;

namespace UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        //[STAThread]
        //static void Main()
        //{
        //    // To customize application configuration such as set high DPI settings or default font,
        //    // see https://aka.ms/applicationconfiguration.
        //    ApplicationConfiguration.Initialize();
        //    Application.Run(new Form1());
        //}
        public static void Main()
        {
            IParser parser = new Parser();
            parser.Text = "011 001";

            try
            {
                parser.ParseText();
                Console.WriteLine("Текст правильный");
            }
            catch(SynAnException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Строка: {0}\nПозиция: {1}", ex.LineIndex, ex.SymIndex);
            }
            catch (LexAnException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Строка: {0}\nПозиция: {1}", ex.LineIndex, ex.SymIndex);
            }
        }
    }
}