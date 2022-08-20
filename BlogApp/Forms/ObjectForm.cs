using System;
using System.Data.Common;
using BlogApp.Utils;

namespace BlogApp.Forms
{
    /// <summary>
    /// Форма выбора объекта
    /// </summary>
    public class ObjectForm
    {
        // Поле для хранения экземпляра класса
        private static ObjectForm instance;
        
        /// <summary>
        /// Возврат экземпляра класса
        /// </summary>
        /// <returns>Экземпляр класса</returns>
        public static ObjectForm GetInstance()
        {
            if (instance == null)
                instance = new ObjectForm();
            return instance;
        }
        
        /// <summary>
        /// Начать
        /// </summary>
        public void Start()
        {
            ColorUtil.SystemMessageWriteLine("Выберете действие:");
            ColorUtil.SystemMessageWriteLine("[1] - Узнать про папки");
            ColorUtil.SystemMessageWriteLine("[2] - Узнать про статьи");

            try
            {
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1: 
                        FolderForm.GetInstance().Start();
                        break;
                    case 2:
                        ArticleForm.GetInstance().Start();
                        break;
                    default:
                        StaticWordsUtils.PrintInvalidInputSignCase();
                        Start();
                        break;
                }
            }
            catch
            {
                StaticWordsUtils.PrintInvalidInputSignCase();
                Start();
            }
        }
    }
}