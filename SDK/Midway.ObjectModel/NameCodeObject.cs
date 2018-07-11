using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Связка код - наименование.
    /// </summary>
    [DataContract]
    public class NameCodeObject
    {
        /// <summary>
        /// Код.
        /// </summary>
        [DataMember]
        public string Code { get; set; }

        /// <summary>
        /// Имя объекта.
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}
