namespace BlogApp.Utils
{
    /// <summary>
    /// Утилита по ключевым фразам системы
    /// </summary>
    public static class StaticWordsUtils
    {
        /// <summary>
        /// Неверное значение в кейсах
        /// </summary>
        public static void PrintInvalidInputSignCase() =>
            ColorUtil.ErrorMessageWriteLine("Нужно вводить значение, которое показано в квадратных скобках []");
        
        /// <summary>
        /// Любое неверное введенное значение
        /// </summary>
        public static void PrintInvalidInput() =>
            ColorUtil.ErrorMessageWriteLine("Введено неверное значение");
        
        /// <summary>
        /// Ошибка
        /// </summary>
        public static void PrintError() =>
            ColorUtil.ErrorMessageWriteLine("Внимание! Произошла ошибка. Подробнее смотрите в логах");
    }
}