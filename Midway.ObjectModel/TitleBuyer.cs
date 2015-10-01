using System;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Титул покупателя (заказчика)
    /// </summary>
    public class TitleBuyer
    {
        /// <summary>
        /// Дата подтверждения
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Дата формирования документа (титул покупателя) 
        /// </summary>
        public DateTime DateBuyer { get; set; }

        /// <summary>
        /// Имя файла подтверждения
        /// </summary>
        public string TitleFileName { get; set; }

        /// <summary>
        /// Информация по доверенности
        /// </summary>
        public ProcurationInfo Procuration { get; set; }

        /// <summary>
        /// Реквизиты принимающего
        /// </summary>
        public PersonInfo ReceptorInfo { get; set; }

        /// <summary>
        /// Реквизиты получателя
        /// </summary>
        public PersonInfo RecipientInfo { get; set; }

        /// <summary>
        /// Код получателя
        /// </summary>
        public string BuyerServiceCode { get; set; }

        /// <summary>
        /// Реквизиты спецоператора
        /// </summary>
        public SubjectInfo SpecialOperatorInfo { get; set; }

        /// <summary>
        /// Сервисный код отправителя
        /// </summary>
        public string SenderServiceCode { get; set; }

        /// <summary>
        /// Имя файла
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Информация о подписанте
        /// </summary>
        public SignerInfo SignerInfo { get; set; }

        /// <summary>
        /// Признак, указывающий тип титула
        /// </summary>
        public TitleType TitleType { get; set; }

        /// <summary>
        /// Информация о документе
        /// </summary>
        public DocumentInfo DocumentNumDateInfo { get; set; }
    }
}
