using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel.GeneralTransferCorrectionV3
{
    /// <summary>
    /// Сведения о факте согласования.
    /// </summary>
    [DataContract]
    public class ApprovalFactData
    {
        /// <summary>
        /// Дата направления на согласование.
        /// </summary>
        [DataMember]
        public DateTime DateSendingApproval { get; set; }

        /// <summary>
        /// Содержание операции.
        /// </summary>
        [DataMember]
        public string OperationDescription { get; set; }

        /// <summary>
        /// Иные сведения об изменении стоимости.
        /// </summary>
        [DataMember]
        public string CostChangesInfo { get; set; }

        /// <summary>
        /// Реквизиты передаточных документов.
        /// </summary>
        [DataMember]
        public List<BasisDocument> TransferDocuments { get; set; }

        /// <summary>
        /// Реквизиты документов-оснований корректировки.
        /// </summary>
        [DataMember]
        public List<BasisDocument> BasisDocuments { get; set; }
    }
}
