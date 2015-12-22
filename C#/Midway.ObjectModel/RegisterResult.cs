using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    [DataContract]
    public class RegisterResult
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public RegisterResult()
        {
            ErrorMessages = new List<string>(); 
            ErrorMembers = new List<string>();
        }

        /// <summary>
        /// Зарегистрированный пользователь
        /// </summary>
        [DataMember]
        public RegisterModel RegisterModel { get; set; }

        /// <summary>
        /// Ошибки при регистрации. Коллекция может быть пустой, но никогда не будет null.
        /// </summary>
        [DataMember]
        //TODO перделывать!
        public List<string> ErrorMessages { get; set; }

        /// <summary>
        /// Получает коллекцию имен членов, не прошедших валидацию. Коллекция может быть пустой, но никогда не будет null.
        /// </summary>
        [DataMember]
        public List<string> ErrorMembers { get; set; }

        /// <summary>
        /// Результат регистрации. 
        /// Если регистрация прошла успешно, то возвращает true, иначе возвращает false
        /// </summary>
        [DataMember]
        public bool Success { get; set; }
    }
}