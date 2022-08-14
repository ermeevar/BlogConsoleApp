using System;
using System.Text;
using BlogApp.Utils;

namespace BlogApp.Forms
{
    /// <summary>
    /// Форма старта 
    /// </summary>
    public class StartForm
    {
        /// <summary>
        /// Утилита счетчик
        /// </summary>
        private CountUtil CountUtil => new CountUtil();
        
        /// <summary>
        /// Начать
        /// </summary>
        public void Start()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            ColorUtil.SystemMessageWriteLine("~БЛОГ РУФИНЫ~");
            CountUtil.PrintShortCounts();

            new ObjectForm().Start();
        }
    }
}