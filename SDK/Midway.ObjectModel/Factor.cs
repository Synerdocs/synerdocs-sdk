using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Фактор
    /// </summary>
    [DataContract]
    public class Factor: ContragentBase
    {
        /// <summary>
        /// Телефон фактора
        /// </summary>
        [DataMember]
        public string Phone { get; set; }

        /// <summary>
        /// Адрес фактора
        /// </summary>
        [DataMember]
        public string Address { get; set; }
    }
}
