using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Данные организации подписанта простой ЭП.
    /// </summary>
    [DataContract]
    public class SimpleSignatureOrganization
    {
        /// <summary>
        /// Наименование.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Name { get; set; }

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
        /// Сведения о государственной регистрации ИП.
        /// </summary>
        [DataMember]
        public string StateRegistrationCert { get; set; }
    }
}
