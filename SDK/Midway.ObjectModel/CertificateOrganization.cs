using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Реквизиты организации в сертификате.
    /// </summary>
    [DataContract]
    public class CertificateOrganization
    {
        /// <summary>
        /// Тип организации.
        /// </summary>
        [DataMember(IsRequired = true)]
        public EnumValue OrganizationType { get; set; }

        /// <summary>
        /// Полное наименование организации.
        /// </summary>
        [DataMember]
        public string FullName { get; set; }

        /// <summary>
        /// Краткое наименование организации.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string ShortName { get; set; }

        /// <summary>
        /// ИНН.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Inn { get; set; }

        /// <summary>
        /// КПП.
        /// </summary>
        [DataMember]
        public string Kpp { get; set; }

        /// <summary>
        /// ОГРН.
        /// </summary>
        [DataMember]
        public string Ogrn { get; set; }

        /// <summary>
        /// Юридический адрес.
        /// </summary>
        [DataMember(IsRequired = true)]
        public CertificateAddress LegalAddress { get; set; }

        /// <summary>
        /// Фактический адрес.
        /// </summary>
        [DataMember]
        public CertificateAddress ActualAddress { get; set; }

        /// <summary>
        /// Номер контактного телефона.
        /// </summary>
        [DataMember]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Номер контактного мобильного телефона. 
        /// На этот номер будут поступать СМС для авторизации.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string MobilePhoneNumber { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        [DataMember]
        public string Email { get; set; }
    }
}
