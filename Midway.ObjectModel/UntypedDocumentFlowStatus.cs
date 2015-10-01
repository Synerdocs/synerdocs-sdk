using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Статус неформализованного документа
    /// </summary>
    [DataContract]
    public class UntypedDocumentFlowStatus : DocumentFlowStatus
    {
        /// <summary>
        /// Статус доставки документа
        /// </summary>
        [DataMember]
        public DocumentDeliveryStatus DeliveryStatus { get; set; }

        /// <summary>
        /// Статус подписания документа получателем
        /// </summary>
        [DataMember]
        public DocumentSignStatus SignStatus { get; set; }
        
        /// <summary>
        /// Дополнительный статус
        /// </summary>
        [DataMember]
        public string AdditionalStatus { get; set; }

        protected bool Equals(UntypedDocumentFlowStatus other)
        {
            return DeliveryStatus == other.DeliveryStatus && SignStatus == other.SignStatus && string.Equals(AdditionalStatus, other.AdditionalStatus);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((UntypedDocumentFlowStatus) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int) DeliveryStatus;
                hashCode = (hashCode * 397) ^ (int) SignStatus;
                hashCode = (hashCode * 397) ^ (AdditionalStatus != null ? AdditionalStatus.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return string.Format(
                "Статус доставки документа: {0}, " +
                "Статус подписания документа получателем: {1}",
                DeliveryStatus,
                SignStatus) +
                   (string.IsNullOrEmpty(AdditionalStatus)
                        ? string.Empty
                        : ", Дополнительный статус: " + AdditionalStatus);
        }
    }
}
