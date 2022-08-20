using System;
using BlogApp.Entities;
using BlogApp.Services;
using BlogApp.Utils;

namespace BlogApp.Forms
{
    /// <summary>
    /// Форма cтатьи
    /// </summary>
    public class ArticleForm
    {
        // Поле для хранения экземпляра класса
        private static ArticleForm instance;
 
        /// <summary>
        /// Сервис статей
        /// </summary>
        private ArticleService ArticleService => new ArticleService();
        
        /// <summary>
        /// Сервис папок
        /// </summary>
        private FolderService FolderService => new FolderService();

        /// <summary>
        /// Уилита счетчик
        /// </summary>
        private CountUtil CountUtil => new CountUtil();
        
        /// <summary>
        /// Возврат экземпляра класса
        /// </summary>
        /// <returns>Экземпляр класса</returns>
        public static ArticleForm GetInstance()
        {
            if (instance == null)
                instance = new ArticleForm();
            return instance;
        }
        
        /// <summary>
        /// Начать
        /// </summary>
        public void Start()
        {
            ColorUtil.SystemMessageWriteLine("Выберете действие:");
            ColorUtil.SystemMessageWriteLine("[1] - Вывести все статьи");
            ColorUtil.SystemMessageWriteLine("[2] - Вывести все статьи по папке");
            ColorUtil.SystemMessageWriteLine("[3] - Прочитать статью");
            ColorUtil.SystemMessageWriteLine("[4] - Добавить статью");
            ColorUtil.SystemMessageWriteLine("[5] - Добавить статью в папку");
            ColorUtil.SystemMessageWriteLine("[6] - На основную страницу");

            try
            {
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1: 
                        PrintArticles();
                        break;
                    case 2:
                        PrintArticlesByFolder();
                        break;
                    case 3:
                        PrintArticle();
                        break;
                    case 4:
                        AddArticle();
                        break;
                    case 5:
                        AddArticleToFolder();
                        break;
                    case 6:
                        GoBack();
                        break;
                    default:
                        StaticWordsUtils.PrintInvalidInputSignCase();
                        Start();
                        break;
                }
            }
            catch
            {
                StaticWordsUtils.PrintError();
                Start();
            }
        }

        /// <summary>
        /// Прочитать статью
        /// </summary>
        private void PrintArticle()
        {
            long articleId = 0;
            ColorUtil.SystemMessageWrite("Введите идентификатор статьи: ");
            try
            {
                articleId = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                StaticWordsUtils.PrintError();
                Start();
            }

            Console.WriteLine();

            Article article = ArticleService.Get(articleId);
            if (article == null)
            {
                ColorUtil.ErrorMessageWriteLine($"Не найдена статья с идентификатором {articleId}");
                Start();
            }
            
            ColorUtil.ArticleHeader(article.Header);
            ColorUtil.ArticleMessage(article.Body);
            ColorUtil.ArticleMessage(article.CreatedDate.ToShortDateString());
            Start();
        }
        
        /// <summary>
        /// Напечатать все статьи
        /// </summary>
        private void PrintArticles()
        {
            foreach(Article article in ArticleService.GetArticles())
                ColorUtil.SystemMessageWriteLine(article.ToString());
            Start();
        }
        
        /// <summary>
        /// Напечатать все статьи по папке
        /// </summary>
        private void PrintArticlesByFolder()
        {
            long folderId = 0;
            ColorUtil.SystemMessageWrite("Введите идентификатор папки: ");
            try
            {
                folderId = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                StaticWordsUtils.PrintInvalidInput();
                Start();
            }

            Folder folder = FolderService.GetFolder(folderId);
            if (folder == null)
            {
                ColorUtil.ErrorMessageWriteLine($"Не найдена папка с идентификатором {folderId}");
                Start();
            }
            ColorUtil.SystemMessageWriteLine(folder.ToString());
            
            foreach(Article article in ArticleService.GetArticlesByFolder(folderId))
                ColorUtil.SystemMessageWriteLine(article.ToString()); 
            Start();
        }

        /// <summary>
        /// Добавить статью
        /// </summary>
        private void AddArticle()
        {
            ColorUtil.SystemMessageWriteLine("Введите заголовок статьи: ");
            string header = Console.ReadLine();
            
            ColorUtil.SystemMessageWriteLine("Введите текст статьи: ");
            string body = Console.ReadLine();

            if (!ArticleService.Add(header, body))
            {
                StaticWordsUtils.PrintError();
                Start();
            }
            
            CountUtil.PrintShortCounts();
            Start();
        }

        /// <summary>
        /// Добавить статью в папку
        /// </summary>
        private void AddArticleToFolder()
        {
            long folderId = 0;
            ColorUtil.SystemMessageWrite("Введите идентификатор папки: ");
            try
            {
                folderId = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                StaticWordsUtils.PrintInvalidInput();
                Start();
            }
            
            long articleId = 0;
            ColorUtil.SystemMessageWrite("Введите идентификатор статьи: ");
            try
            {
                articleId = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                StaticWordsUtils.PrintInvalidInput();
                Start();
            }
            
            if (!ArticleService.AddArticleToFolder(articleId, folderId))
            {
                StaticWordsUtils.PrintError();
                Start();
            }
            
            CountUtil.PrintShortCounts();
            Start();
        }

        /// <summary>
        /// Вернуться на предыдущую страницу
        /// </summary>
        private void GoBack()
        {
            ObjectForm.GetInstance().Start();
        }
    }
}