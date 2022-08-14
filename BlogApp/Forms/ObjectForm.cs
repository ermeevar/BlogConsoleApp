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
                        new FolderForm().Start();
                        break;
                    case 2:
                        new ArticleForm().Start();
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