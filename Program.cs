namespace AntiSngEx
{
    using System;

    internal static class Program
    {
        [STAThread]
        public static void Main()
        {
			// Проверяем нашу страну если есть то выходим.
            if (ContryClass.CheckContry()) { Environment.Exit(0); } // Далее ваш код
			// ... Тут всё будет работать...
            Console.ReadKey();
        }
    }
}