using System;
using BlogApp.Entities;
using BlogApp.Services;
using BlogApp.Utils;

namespace BlogApp.Forms
{
    /// <summary>
    /// Форма папки
    /// </summary>
    public class FolderForm
    {
        // Поле для хранения экземпляра класса
        private static FolderForm instance;
        
        /// <summary>
        /// Сервис статей
        /// </summary>
        private ArticleService ArticleService => new ArticleService();
        
        /// <summary>
        /// Сервис папок
        /// </summary>
        private FolderService FolderService => new FolderService();

        /// <summary>
        /// Утилита счетчик
        /// </summary>
        private CountUtil CountUtil => new CountUtil();
        
        /// <summary>
        /// Возврат экземпляра класса
        /// </summary>
        /// <returns>Экземпляр класса</returns>
        public static FolderForm GetInstance()
        {
            if (instance == null)
                instance = new FolderForm();
            return instance;
        }
        
        /// <summary>
        /// Начать
        /// </summary>
        public void Start()
        {
            ColorUtil.SystemMessageWriteLine("Выберете действие:");
            ColorUtil.SystemMessageWriteLine("[1] - Вывести все папки");
            ColorUtil.SystemMessageWriteLine("[2] - Добавить папку");
            ColorUtil.SystemMessageWriteLine("[3] - Удалить папку");
            ColorUtil.SystemMessageWriteLine("[4] - На основную страницу");

            try
            {
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1: 
                        PrintFolders();
                        break;
                    case 2:
                        AddFolder();
                        break;
                    case 3:
                        RemoveFolder();
                        break;
                    case 4:
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
                StaticWordsUtils.PrintInvalidInputSignCase();
                Start();
            }
        }
        
        /// <summary>
        /// Напечатать все папки
        /// </summary>
        private void PrintFolders()
        {
            foreach(Folder folder in FolderService.GetFolders())
                ColorUtil.SystemMessageWriteLine(folder.ToString());
            Start();
        }
        
        /// <summary>
        /// Добавить папку
        /// </summary>
        private void AddFolder()
        {
            ColorUtil.SystemMessageWriteLine("Введите наименование папки: ");
            string name = Console.ReadLine();

            if (!FolderService.Add(name))
            {
                StaticWordsUtils.PrintError();
                Start();
            }
            
            CountUtil.PrintShortCounts();
            Start();
        }
        
        /// <summary>
        /// Удалить папку
        /// </summary>
        private void RemoveFolder()
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
            
            if (!FolderService.Remove(folderId))
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