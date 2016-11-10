using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Сведения о факте согласования
    /// </summary>
    [DataContract] 
    public class ApprovalArea
    {
        /// <summary>
        /// Основание корректировки
        /// </summary>
        [DataMember]
        public BasisDocument[] BasisDocuments { get; set; }

        /// <summary>
        /// Сведения о согласовании изменений
        /// </summary>
        [DataMember]
        public ApprovalInfo ApprovalInfo { get; set; }

        /// <summary>
        /// Иные сведения об изменении стоимости
        /// </summary>
        [DataMember]
        public string CorrectionAdditionalInfo { get; set; }

        /// <summary>
        /// Реквизиты передаточных (отгрузочных) документов, к которым относится корректировка
        /// </summary>
        [DataMember]
        public string TransferDocumentsRequisites { get; set; }
    }
}
