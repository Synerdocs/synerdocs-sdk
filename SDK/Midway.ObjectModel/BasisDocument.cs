using System.Runtime.Serialization;
using System;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Документ-основание
    /// </summary>
    [DataContract]
    public class BasisDocument
    {
        /// <summary>
        /// Наименование основания
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Номер основания
        /// </summary>
        [DataMember]
        public string Number { get; set; }

        /// <summary>
        /// Дата основания
        /// </summary>
        [DataMember]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Дополнительные сведения
        /// </summary>
        [DataMember]
        public string AdditionalInfo { get; set; }
    }
}
