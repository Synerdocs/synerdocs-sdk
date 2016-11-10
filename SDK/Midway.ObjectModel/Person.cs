using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация о лице, передавшем (отпустившем) товар (груз)
    /// </summary>
    [DataContract]
    public class Person
    {
        /// <summary>
        /// ФИО
        /// </summary>
        [DataMember]
        public FullName FullName { get; set; }

        /// <summary>
        /// Должность
        /// </summary>
        [DataMember]
        public string Position { get; set; }

        /// <summary>
        /// Дополнительные сведения
        /// </summary>
        [DataMember]
        public string AdditionalInfo { get; set; }

        /// <summary>
        /// Наименование организации
        /// </summary>
        [DataMember]
        public string OrganizationName { get; set; }

        /// <summary>
        /// Основание полномочий
        /// </summary>
        [DataMember]
        public string AuthorityBase { get; set; }

        /// <summary>
        /// Основание доверия
        /// </summary>
        [DataMember]
        public string TrustBase { get; set; }

        /// <summary>
        /// Тип лица, передавшего (отпустившего) товар (груз)
        /// </summary>
        [DataMember]
        public EnumValue PersonType { get; set; }
    }
}
