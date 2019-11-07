using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// ФИО.
    /// </summary>
    [DataContract]
    public class FullName
    {
        /// <summary>
        /// Имя.
        /// </summary>
        [DataMember]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        [DataMember]
        public string LastName { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        [DataMember]
        public string MiddleName { get; set; }
    }
}
