using System;
using System.Linq;
using System.Runtime.Serialization;
using Midway.ObjectModel.Extensions;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Статус неформализованного документа, отправленного нескольким получателям
    /// </summary>
    [DataContract]
    public class UntypedDocumentMultiFlowStatus
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public UntypedDocumentMultiFlowStatus()
        {
        }

        /// <summary>
        /// Конструктор на основе статусов получателей
        /// </summary>
        /// <param name="statuses"></param>
        public UntypedDocumentMultiFlowStatus(UntypedDocumentFlowStatus[] statuses)
        {
            // Вычислить статус доставки
            var deliveredCount = statuses.Count(r => r.DeliveryStatus == DocumentDeliveryStatus.DeliveredToRecipient);
            var multiDeliveryStatus = DocumentMultiDeliveryStatus.SentToRecipients;
            if (deliveredCount == statuses.Length)
            {
                multiDeliveryStatus = DocumentMultiDeliveryStatus.DeliveredToRecipients;
            } 
            else if (Array.Exists(statuses, s => s.DeliveryStatus == DocumentDeliveryStatus.NotDeliveredToRecipient))
            {
                multiDeliveryStatus = DocumentMultiDeliveryStatus.NotDeliveredToRecipients;
            }
            else if (Array.Exists(statuses, s => s.DeliveryStatus == DocumentDeliveryStatus.RecievedByService))
            {
                multiDeliveryStatus = DocumentMultiDeliveryStatus.RecievedByService;
            }
            else if (deliveredCount > 0)
            {
                multiDeliveryStatus = DocumentMultiDeliveryStatus.PartlyDeliveredToRecipients;
            }
            
            // Вычислить статус подписания
            var signedCount = statuses.Count(r => r.SignStatus == DocumentSignStatus.Signed);
            var multiSignStatus = DocumentMultiSignStatus.WaitingForSign;
            if (signedCount == statuses.Length)
            {
                multiSignStatus = DocumentMultiSignStatus.Signed;
            }
            else if (Array.Exists(statuses, s => s.SignStatus == DocumentSignStatus.SignRejected))
            {
                multiSignStatus = DocumentMultiSignStatus.SignRejected;
            }
            else if (Array.Exists(statuses, s => s.SignStatus == DocumentSignStatus.NoSignNeeded))
            {
                multiSignStatus = DocumentMultiSignStatus.NoSignNeeded;
            }
            else if (signedCount > 0)
            {
                multiSignStatus = DocumentMultiSignStatus.PartlySigned;
            }

            this.MultiDeliveryStatus = multiDeliveryStatus;
            this.MultiSignStatus = multiSignStatus;
            this.DeliveredCount = deliveredCount;
            this.SignedCount = signedCount;
            this.RecipientsCount = statuses.Length;
        }
        
        /// <summary>
        /// Статус доставки документа получателям
        /// </summary>
        [DataMember]
        public DocumentMultiDeliveryStatus MultiDeliveryStatus { get; set; }

        /// <summary>
        /// Статус подписания документа получателями
        /// </summary>
        [DataMember]
        public DocumentMultiSignStatus MultiSignStatus { get; set; }

        /// <summary>
        /// Количество получателей, кому доставлен документ
        /// </summary>
        [DataMember]
        public int DeliveredCount { get; set; }

        /// <summary>
        /// Количество получателей, подписавших документ
        /// </summary>
        [DataMember]
        public int SignedCount { get; set; }

        /// <summary>
        /// Количество получателей
        /// </summary>
        [DataMember]
        public int RecipientsCount { get; set; }

        protected bool Equals(UntypedDocumentMultiFlowStatus other)
        {
            return MultiDeliveryStatus.Equals(other.MultiDeliveryStatus) 
                && MultiSignStatus.Equals(other.MultiSignStatus);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UntypedDocumentMultiFlowStatus)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (MultiDeliveryStatus.GetHashCode() * 397) ^ MultiSignStatus.GetHashCode();
            }
        }

        public override string ToString()
        {
            return string.Format("Статус доставки документа получателям: {0}, Статус подписания документа получателями: {1}", MultiDeliveryStatus, MultiSignStatus);
        }

        /// <summary>
        /// Преобразовать в тип UntypedDocumentFlowStatus
        /// </summary>
        /// <returns></returns>
        public UntypedDocumentFlowStatus ToUntypedDocumentFlowStatus()
        {
            return
                new UntypedDocumentFlowStatus()
                    {
                        DeliveryStatus = MultiDeliveryStatus.ToDocumentDeliveryStatus(),
                        SignStatus = MultiSignStatus.ToDocumentSignStatus(),
                    };
        }
    }
}
