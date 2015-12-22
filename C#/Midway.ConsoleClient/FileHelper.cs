using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;

namespace Midway.ConsoleClient
{
    /// <summary>
    /// Хелпер для работы с файлами
    /// </summary>
    public static class FileHelper
    {
        private static readonly Regex InvalidFilePathRegex;
        private static readonly Regex InvalidFileNameRegex;
        private static readonly Regex InvalidFullPathRegex;

        static FileHelper()
        {
            var invalidFilePathChars = Path.GetInvalidPathChars();
            var invalidFileNameChars = Path.GetInvalidFileNameChars();
            var invalidFullPathChars = invalidFilePathChars
                .Concat(invalidFileNameChars)
                .Distinct()
                .ToArray();

            InvalidFilePathRegex = CreateInvalidRegex(invalidFilePathChars);
            InvalidFileNameRegex = CreateInvalidRegex(invalidFileNameChars);
            InvalidFullPathRegex = CreateInvalidRegex(invalidFullPathChars);
        }

        /// <summary>
        /// Создает регулярное выражение для удаления запрещенных символов
        /// </summary>
        /// <param name="invalidChars">Запрещенные символы</param>
        /// <returns>Регулярное выражение</returns>
        private static Regex CreateInvalidRegex(char[] invalidChars)
        {
            var invalidString = new String(invalidChars);
            invalidString = Regex.Escape(invalidString);
            invalidString = String.Format("[{0}]", invalidString);
            return new Regex(invalidString); 
        }

        /// <summary>
        /// Удаляет запрещенные символы из пути к файлу
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <returns>Путь к файлу с удаленными запрещенными символами</returns>
        public static string RemoveInvalidPathNameChars(string filePath)
        {
            return InvalidFilePathRegex.Replace(filePath, String.Empty);
        }

        /// <summary>
        /// Удаляет запрещенные символы из имени файла
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <returns>Имя файла с удаленными запрещенными символами</returns>
        public static string RemoveInvalidFileNameChars(string fileName)
        {
            return InvalidFileNameRegex.Replace(fileName, String.Empty);
        }

        /// <summary>
        /// Удаляет запрещенные символы из полного пути
        /// </summary>
        /// <param name="fullPath">Полный путь</param>
        /// <returns>Полный путь с удаленными запрещенными символами</returns>
        public static string RemoveInvalidFullPathChars(string fullPath)
        {
            return InvalidFullPathRegex.Replace(fullPath, String.Empty);
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
    }
}
