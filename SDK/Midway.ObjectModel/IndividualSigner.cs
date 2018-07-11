using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Подписант - физическое лицо.
    /// </summary>
    [DataContract]
    public class IndividualSigner : SignerBase
    {
        /// <summary>
        /// Свидетельство государственной регистрации ИП,
        /// выдавшего доверенность физическому лицу на подписание счета-фактуры.
        /// </summary>
        [DataMember]
        public string StateRegistrationCert { get; set; }

        /// <summary>
        /// ИНН физического лица.
        /// </summary>
        [DataMember]
        public string Inn { get; set; }
    }
}
