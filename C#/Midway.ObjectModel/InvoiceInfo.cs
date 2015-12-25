using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация о счете-фактуре
    /// </summary>
    [DataContract]
    public class InvoiceInfo
    {
        /// <summary>
        /// Название счета-фактуры в формате "Счет-фактура №... от __.__.____ г."
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Номер счета-фактуры
        /// </summary>
        [DataMember]
        public string Number { get; set; }

        /// <summary>
        /// Дата счета-фактуры
        /// </summary>
        [DataMember]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Номер исправления счета-фактуры
        /// </summary>
        [DataMember]
        public string ChangesNumber { get; set; }

        /// <summary>
        /// Дата исправления счета-фактуры
        /// </summary>
        [DataMember]
        public DateTime? ChangesDate { get; set; }

        /// <summary>
        /// Номер корректировки счета-фактуры
        /// </summary>
        [DataMember]
        public string CorrectionNumber { get; set; }

        /// <summary>
        /// Дата корректировки счета-фактуры
        /// </summary>
        [DataMember]
        public DateTime? CorrectionDate { get; set; }

        /// <summary>
        /// Номер исправления корректировки счета-фактуры
        /// </summary>
        [DataMember]
        public string ChangeCorrectionNumber { get; set; }

        /// <summary>
        /// Дата исправления корректировки счета-фактуры
        /// </summary>
        [DataMember]
        public DateTime? ChangeCorrectionDate { get; set; }

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
