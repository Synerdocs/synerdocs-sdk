using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация об операции
    /// </summary>
    [DataContract]
    public class OperationInfo
    {
        /// <summary>
        /// Содержание операции
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Дата операции
        /// </summary>
        [DataMember]
        public DateTime? Date { get; set; }
    }
}
