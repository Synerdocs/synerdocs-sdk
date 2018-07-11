using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Базовый класс подписанта.
    /// </summary>
    [DataContract]
    [KnownType(typeof(LegalEntitySigner))]
    [KnownType(typeof(IndividualEntrepreneurSigner))]
    [KnownType(typeof(IndividualSigner))]
    public class SignerBase
    {
        /// <summary>
        /// Дата подписания.
        /// </summary>
        [DataMember]
        public DateTime? SignedAt { get; set; }

        /// <summary>
        /// ФИО подписанта.
        /// </summary>
        [DataMember]
        public FullName FullName { get; set; }

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
        /// Иные сведения, идентифицирующие физическое лицо.
        /// </summary>
        [DataMember]
        public string AdditionalInfo { get; set; }
    }
}