using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Массив данных с именем. Используется для передачи содержимого файла с именем.
    /// </summary>
    [DataContract]
    public class NamedContent
    {
        /// <summary>
        /// Название
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Соджержимое
        /// </summary>
        [DataMember]
        public byte[] Content { get; set; }
    }
}