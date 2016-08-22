using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    [DataContract]
    public class TagUser
    {
        /// <summary>
        /// Логин
        /// </summary>
        [DataMember]
        public string Login { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [DataMember]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [DataMember]
        public string LastName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        [DataMember]
        public string MiddleName { get; set; }

        /// <summary>
        /// Должность
        /// </summary>
        [DataMember]
        public string Position { get; set; }
    }
}
