using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запись табличных данных универсального корректировочного документа до и после корректирования
    /// </summary>
    [DataContract]
    public class GeneralTransferCorrectionItem
    {
        /// <summary>
        /// Табличные данные До корректирования
        /// </summary>
        [DataMember]
        public GeneralTransferItemData Before { get; set; }

        /// <summary>
        /// Табличные данные После корректирования
        /// </summary>
        [DataMember]
        public GeneralTransferItemData After { get; set; }

        /// <summary>
        /// Информация по разнице до и после
        /// </summary>
        [DataMember]
        public GeneralTransferItemChange Change { get; set; }

        /// <summary>
        /// Номер
        /// </summary>
        [DataMember]
        public int Number { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Корректировочный дебетовый счет
        /// </summary>
        [DataMember]
        public string DebitAccount { get; set; }

        /// <summary>
        /// Корректировочный кредитовый счет
        /// </summary>
        [DataMember]
        public string CreditAccount { get; set; }

        /// <summary>
        /// Информационное поле
        /// </summary>
        [DataMember]
        public NameCodeObject[] InfoTexts { get; set; }
    }
}