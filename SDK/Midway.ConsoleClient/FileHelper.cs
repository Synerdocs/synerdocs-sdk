using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Midway.ConsoleClient
{
    /// <summary>
    /// Хелпер для работы с файлами
    /// </summary>
    public static class FileHelper
    {
        private static readonly Regex _invalidFilePathRegex;
        private static readonly Regex _invalidFileNameRegex;
        private static readonly Regex _invalidFullPathRegex;

        static FileHelper()
        {
            var invalidFilePathChars = Path.GetInvalidPathChars();
            var invalidFileNameChars = Path.GetInvalidFileNameChars();
            var invalidFullPathChars = invalidFilePathChars
                .Concat(invalidFileNameChars)
                .Distinct()
                .ToArray();

            _invalidFilePathRegex = CreateInvalidRegex(invalidFilePathChars);
            _invalidFileNameRegex = CreateInvalidRegex(invalidFileNameChars);
            _invalidFullPathRegex = CreateInvalidRegex(invalidFullPathChars);
        }

        /// <summary>
        /// Создает регулярное выражение для удаления запрещенных символов
        /// </summary>
        /// <param name="invalidChars">Запрещенные символы</param>
        /// <returns>Регулярное выражение</returns>
        private static Regex CreateInvalidRegex(char[] invalidChars)
        {
            var invalidString = new string(invalidChars);
            invalidString = Regex.Escape(invalidString);
            invalidString = string.Format("[{0}]", invalidString);
            return new Regex(invalidString);
        }

        /// <summary>
        /// Удаляет запрещенные символы из пути к файлу
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <returns>Путь к файлу с удаленными запрещенными символами</returns>
        public static string RemoveInvalidPathNameChars(string filePath)
        {
            return _invalidFilePathRegex.Replace(filePath, string.Empty);
        }

        /// <summary>
        /// Удаляет запрещенные символы из имени файла
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <returns>Имя файла с удаленными запрещенными символами</returns>
        public static string RemoveInvalidFileNameChars(string fileName)
        {
            return _invalidFileNameRegex.Replace(fileName, string.Empty);
        }

        /// <summary>
        /// Удаляет запрещенные символы из полного пути
        /// </summary>
        /// <param name="fullPath">Полный путь</param>
        /// <returns>Полный путь с удаленными запрещенными символами</returns>
        public static string RemoveInvalidFullPathChars(string fullPath)
        {
            return _invalidFullPathRegex.Replace(fullPath, string.Empty);
        }

        /// <summary>
        /// Создает файл и записывает в него все данные
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <param name="fileName">Имя файла</param>
        /// <param name="fileData">Данные файла</param>
        public static void WriteAllBytes(string filePath, string fileName, byte[] fileData)
        {
            var validPath = RemoveInvalidPathNameChars(filePath);
            var validName = RemoveInvalidFileNameChars(fileName);
            var fullPath = Path.Combine(validPath, validName);
            File.WriteAllBytes(fullPath, fileData);
        }

        /// <summary>
        /// Получить контент файла
        /// </summary>
        /// <param name="fullFilePath">Полный путь к файлу (включая наименование)</param>
        /// <returns></returns>
        public static byte[] GetFileContent(string fullFilePath)
        {
            var validPath = RemoveInvalidPathNameChars(fullFilePath);
            return File.ReadAllBytes(validPath);
        }

        /// <summary>
        /// Проверить существование файла
        /// </summary>
        /// <param name="fullFilePath">Полный путь к файлу (включая наименование)</param>
        /// <returns></returns>
        public static bool FileExists(string fullFilePath)
        {
            var validPath = RemoveInvalidPathNameChars(fullFilePath);
            return File.Exists(validPath);
        }
    }
}