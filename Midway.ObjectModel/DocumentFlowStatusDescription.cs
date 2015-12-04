using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Класс, дающий текстовое описание полного 
    /// текущего статуса документооборота относительно абонента
    /// </summary>
    [DataContract]
    public class DocumentFlowStatusDescription
    {
        /// <summary>
        /// Статус документооборота
        /// </summary>
        [DataMember]
        public string Status { get; set; }

        /// <summary>
        /// Дополнительный статус документооборота
        /// </summary>
        [DataMember]
        public string AdditionalStatus { get; set; }
    }
}
