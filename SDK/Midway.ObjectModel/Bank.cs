using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Банк.
    /// </summary>
    [DataContract]
    public class Bank
    {
        /// <summary>
        /// Наименование банка.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// БИК (Банковский идентификационный код).
        /// </summary>
        [DataMember]
        public string Bik { get; set; }
    }
}
