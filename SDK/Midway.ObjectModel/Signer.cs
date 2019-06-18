using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация о подписанте
    /// </summary>
    [DataContract]
    public class Signer
    {
        /// <summary>
        /// Тип организации.
        /// </summary>
        [DataMember]
        public EnumValue OrganizationType { get; set; }

        /// <summary>
        /// ИНН организации.
        /// </summary>
        [DataMember]
        public string Inn { get; set; }

        /// <summary>
        /// Должность подписанта.
        /// </summary>
        [DataMember]
        public string Position { get; set; }

        /// <summary>
        /// Свидетельство государственной регистрации ИП.
        /// </summary>
        [DataMember]
        public string StateRegistrationCert { get; set; }

        /// <summary>
        /// ФИО подписанта.
        /// </summary>
        [DataMember]
        public FullName FullName { get; set; }

        /// <summary>
        /// Наименование организации.
        /// </summary>
        [DataMember]
        public string OrganizationName { get; set; }

        /// <summary>
        /// Основание полномочий (доверия).
        /// </summary>
        [DataMember]
        public string AuthorityBase { get; set; }

        /// <summary>
        /// Основание полномочий (доверия) для организации.
        /// </summary>
        [DataMember]
        public string OrganizationAuthorityBase { get; set; }

        /// <summary>
        /// Область полномочий.
        /// </summary>
        [DataMember]
        public EnumValue AuthorityArea { get; set; }

        /// <summary>
        /// Тип подписанта, соответствует перечислению <see cref="Midway.ObjectModel.SignerType"/>
        /// </summary>
        [DataMember]
        public EnumValue SignerType { get; set; }

        /// <summary>
        /// Дополнительная информация.
        /// </summary>
        [DataMember]
        public string AdditionalInfo { get; set; }
    }
}