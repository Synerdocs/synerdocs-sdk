using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Контактные данные контрагента
    /// </summary>
    [DataContract]
    public class ContragentContactInfo
    {
        /// <summary>
        /// Телефон
        /// </summary>
        [DataMember]
        public string Phone { get; set; }

        /// <summary>
        /// Факс
        /// </summary>
        [DataMember]
        public string Fax { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [DataMember]
        public string Email { get; set; }
    }
}
