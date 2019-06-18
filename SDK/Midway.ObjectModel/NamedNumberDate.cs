using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Именованный номер/дата.
    /// </summary>
    [DataContract]
    public class NamedNumberDate : NumberDate
    {
        /// <summary>
        /// Наименование.
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}
