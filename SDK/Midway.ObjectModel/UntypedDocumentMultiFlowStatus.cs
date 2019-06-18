using System.Runtime.Serialization;
using Midway.ObjectModel.Extensions;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Статус неформализованного документа, отправленного нескольким получателям.
    /// </summary>
    [DataContract]
    public class UntypedDocumentMultiFlowStatus
    {      
        /// <summary>
        /// Статус доставки документа получателям.
        /// </summary>
        [DataMember]
        public DocumentMultiDeliveryStatus MultiDeliveryStatus { get; set; }

        /// <summary>
        /// Статус подписания документа получателями.
        /// </summary>
        [DataMember]
        public DocumentMultiSignStatus MultiSignStatus { get; set; }

        /// <summary>
        /// Количество получателей, кому доставлен документ.
        /// </summary>
        [DataMember]
        public int DeliveredCount { get; set; }

        /// <summary>
        /// Количество получателей, подписавших документ.
        /// </summary>
        [DataMember]
        public int SignedCount { get; set; }

        /// <summary>
        /// Количество получателей.
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
        /// Преобразовать в статус неформализованного документа.
        /// </summary>
        /// <returns>Статус неформализованного документа.</returns>
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
