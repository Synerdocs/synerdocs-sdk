using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Представление информации о субъекте (издателе) 
    /// </summary>
    [DataContract]
    public class X509NameInfo
    {
        /// <summary>
        /// Общее наименование 
        /// </summary>
        [DataMember]
        public string CommonName { get; set; }

        /// <summary>
        /// Наименование организации
        /// </summary>
        [DataMember]
        public string OrganizationName { get; set; }

        /// <summary>
        /// ИНН
        /// </summary>
        [DataMember]
        public string Inn { get; set; }

        /// <summary>
        /// ОГРН
        /// </summary>
        [DataMember]
        public string Ogrn { get; set; }

        /// <summary>
        /// Должность
        /// </summary>
        [DataMember]
        public string Position { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [DataMember]
        public string Email { get; set; }
    }
}
