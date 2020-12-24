using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация о документе
    /// </summary>
    [DataContract]
    public class DocumentInfo
    {
        /// <summary>
        /// Номер документа
        /// </summary>
        [DataMember]
        public string Number { get; set; }

        /// <summary>
        /// Дата составления, указанная в документе
        /// </summary>
        [DataMember]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        [DataMember]
        public DateTime CreateDate { get; set; }
        
        /// <summary>
        /// Идентификатор файла
        /// </summary>
        [DataMember]
        public string IdFile { get; set; }

        /// <summary>
        /// Сумма без НДС
        /// </summary>
        [DataMember]
        public decimal? CoastSum { get; set; }

        /// <summary>
        /// Сумма НДС
        /// </summary>
        [DataMember]
        public decimal? SumNds { get; set; }
    }
}
