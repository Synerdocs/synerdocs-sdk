using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Дополнительные данные по документу.
    /// </summary>
    [DataContract]
    public class AdditionalDocumentData
    {
        /// <summary>
        /// Параметры.
        /// </summary>
        [DataMember]
        public NameValue[] Parameters { get; set; }
    }
}
