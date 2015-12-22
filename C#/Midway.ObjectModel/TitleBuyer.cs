using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Титул покупателя (заказчика)
    /// </summary>
    [DataContract]
    public class TitleBuyer
    {
        /// <summary>
        /// Дата подтверждения
        /// </summary>
        [DataMember]
        public string Date { get; set; }

        /// <summary>
        /// Дата формирования документа (титул покупателя) 
        /// </summary>
        [DataMember]
        public DateTime DateBuyer { get; set; }

        /// <summary>
        /// Имя файла подтверждения
        /// </summary>
        [DataMember]
        public string TitleFileName { get; set; }

        /// <summary>
        /// Информация по доверенности
        /// </summary>
        [DataMember]
        public ProcurationInfo Procuration { get; set; }

        /// <summary>
        /// Реквизиты принимающего
        /// </summary>
        [DataMember]
        public PersonInfo ReceptorInfo { get; set; }

        /// <summary>
        /// Реквизиты получателя
        /// </summary>
        [DataMember]
        public PersonInfo RecipientInfo { get; set; }

        /// <summary>
        /// Код получателя
        /// </summary>
        [DataMember]
        public string BuyerServiceCode { get; set; }

        /// <summary>
        /// Реквизиты спецоператора
        /// </summary>
        [DataMember]
        public SubjectInfo SpecialOperatorInfo { get; set; }

        /// <summary>
        /// Сервисный код отправителя
        /// </summary>
        [DataMember]
        public string SenderServiceCode { get; set; }

        /// <summary>
        /// Имя файла
        /// </summary>
        [DataMember]
        public string FileName { get; set; }

        /// <summary>
        /// Информация о подписанте
        /// </summary>
        [DataMember]
        public SignerInfo SignerInfo { get; set; }

        /// <summary>
        /// Признак, указывающий тип титула
        /// </summary>
        [DataMember]
        public TitleType TitleType { get; set; }

        /// <summary>
        /// Информация о документе
        /// </summary>
        [DataMember]
        public DocumentInfo DocumentNumDateInfo { get; set; }

        /// <summary>
        /// Информационное поле
        /// </summary>
        [DataMember]
        public InfoField InfoField { get; set; }
    }
}
