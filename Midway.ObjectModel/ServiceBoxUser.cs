namespace Midway.ObjectModel
{
    //TODO класс не используется, ссылка на него есть, но по факту не используется
    /// <summary>
    /// Информация о пользователе ящика
    /// Класс не используется
    /// </summary>
    public class ServiceBoxUser
    {
        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Адрес пользователя (почтовый, юридический, e-mail?)
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }
    }
}
