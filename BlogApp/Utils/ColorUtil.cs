using System;

namespace BlogApp.Utils
{
    /// <summary>
    /// Утилита для изменения цвета консоли
    /// </summary>
    public static class ColorUtil
    {
        /// <summary>
        /// Написать системное сообщение
        /// </summary>
        /// <param name="message">Сообщение</param>
        public static void SystemMessageWrite(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        /// <summary>
        /// Написать системной сообщение с новой строки
        /// </summary>
        /// <param name="message">Сообщение</param>
        public static void SystemMessageWriteLine(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        /// <summary>
        /// Написать cообщение c ошибкой с новой строки
        /// </summary>
        /// <param name="message">Сообщение</param>
        public static void ErrorMessageWriteLine(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        /// <summary>
        /// Написать заголовок статьи
        /// </summary>
        /// <param name="message">Сообщение</param>
        public static void ArticleHeader(string message)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"|||{message.ToUpper()}|||");
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        /// <summary>
        /// Написать информацию статьи
        /// </summary>
        /// <param name="message">Сообщение</param>
        public static void ArticleMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}