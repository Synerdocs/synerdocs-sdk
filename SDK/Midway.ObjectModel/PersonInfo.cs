using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация о должностном лице
    /// </summary>
    [DataContract]
    public class PersonInfo
    {
        /// <summary>
        /// Должность
        /// </summary>
        [DataMember]
        public string Position { get; set; }

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
    }
}
