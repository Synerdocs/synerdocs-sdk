using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Значение и его наименование.
    /// </summary>
    [DataContract]
    public class NameValue
    {
        /// <summary>
        /// Наименование.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Значение.
        /// </summary>
        [DataMember]
        public string Value { get; set; }
    }
}
