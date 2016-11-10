using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Идентификация документа Титула исполнителя (покупателя)
    /// </summary>
    [DataContract]
    public class SellerTitleIdentification
    {
        /// <summary>
        /// Идентификатор файла - имя сформированного файла (без расширения)
        /// </summary>
        [DataMember]
        public string FileId { get; set; }

        /// <summary>
        /// Дата и время формирования
        /// </summary>
        [DataMember]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Содержимое электронных подписей
        /// </summary>
        [DataMember]
        public byte[][] Signatures { get; set; }
    }
}
