using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Данные сотрудника, являющегося подписантом простой ЭП.
    /// </summary>
    [DataContract]
    public class SimpleSignatureEmployee
    {
        /// <summary>
        /// Должность.
        /// </summary>
        [DataMember]
        public string Position { get; set; }

        /// <summary>
        /// E-mail.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Email { get; set; }

        /// <summary>
        /// СНИЛС.
        /// </summary>
        [DataMember]
        public string Snils { get; set; }

        /// <summary>
        /// Данные документа, удостоверяющего личность.
        /// </summary>
        [DataMember]
        public string IdentityDocument { get; set; }

        /// <summary>
        /// Код страны (ОКСМ Альфа-3).
        /// </summary>
        [DataMember]
        public string CountryCode { get; set; }

        /// <summary>
        /// ФИО.
        /// </summary>
        [DataMember(IsRequired = true)]
        public FullName FullName { get; set; }
    }
}
