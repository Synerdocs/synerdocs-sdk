using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Подписант - представитель юридического лица.
    /// </summary>
    [DataContract]
    public class LegalEntitySigner : SignerBase
    {
        /// <summary>
        /// Свидетельство государственной регистрации ИП,
        /// выдавшего доверенность организации на подписание счета-фактуры.
        /// </summary>
        [DataMember]
        public string StateRegistrationCert { get; set; }

        /// <summary>
        /// ИНН юридического лица.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Inn { get; set; }

        /// <summary>
        /// Наименование организации.
        /// </summary>
        [DataMember]
        public string OrganizationName { get; set; }

        /// <summary>
        /// Должность подписанта.
        /// </summary>
        [DataMember]
        public string Position { get; set; }
    }
}
