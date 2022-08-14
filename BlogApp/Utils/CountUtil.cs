using BlogApp.Services;

namespace BlogApp.Utils
{
    /// <summary>
    /// Утилита счетчик
    /// </summary>
    public class CountUtil
    {
        /// <summary>
        /// Сервис статей
        /// </summary>
        private ArticleService ArticleService => new ArticleService();
        
        /// <summary>
        /// Сервис папок
        /// </summary>
        private FolderService FolderService => new FolderService();
        
        /// <summary>
        /// Напечатать краткую информацию о количестве папок и статей
        /// </summary>
        public void PrintShortCounts()
        {
            ColorUtil.SystemMessageWriteLine($"На данный момент в системе {ArticleService.GetCount()} статей " +
                                             $"и {FolderService.GetCount()} папок");
        }
    }
}