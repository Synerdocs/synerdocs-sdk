using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Краткая информация о документе
    /// </summary>
    [DataContract]
    public class DocumentShortInfo : NumberDate
    {
        /// <summary>
        /// Наименование документа
        /// </summary>
        [DataMember]
        public string Name { get; set; }  
        
        /// <summary>
        /// Информация об исправлении
        /// </summary>
        [DataMember]
        public NumberDate Revision { get; set; }
    }
}
