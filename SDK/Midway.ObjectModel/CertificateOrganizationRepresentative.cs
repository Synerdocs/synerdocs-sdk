using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Представитель организации в сертификате.
    /// </summary>
    [DataContract]
    public class CertificateOrganizationRepresentative
    {
        /// <summary>
        /// ФИО.
        /// </summary>
        [DataMember(IsRequired = true)]
        public FullName FullName { get; set; }

        /// <summary>
        /// Пол.
        /// </summary>
        [DataMember(IsRequired = true)]
        public EnumValue Gender { get; set; }

        /// <summary>
        /// Гражданство.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Citizenship { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string BirthDate { get; set; }

        /// <summary>
        /// Место рождения.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string BirthPlace { get; set; }

        /// <summary>
        /// СНИЛС.
        /// </summary>
        [DataMember]
        public string Snils { get; set; }

        /// <summary>
        /// Документ, удостоверяющий личность.
        /// </summary>
        [DataMember(IsRequired = true)]
        public CertificateIdentityDocument IdentityDocument { get; set; }

        /// <summary>
        /// Должность.
        /// </summary>
        [DataMember]
        public string Position { get; set; }

        /// <summary>
        /// Подразделение организации представителя.
        /// </summary>
        [DataMember]
        public string OrganizationalUnit { get; set; }

        /// <summary>
        /// Квалификация ЭП.
        /// </summary>
        [DataMember]
        public EnumValue SignQualification { get; set; }

        /// <summary>
        /// Номер мобильного телефона.
        /// </summary>
        [DataMember]
        public string MobilePhoneNumber { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Email { get; set; }
    }
}
