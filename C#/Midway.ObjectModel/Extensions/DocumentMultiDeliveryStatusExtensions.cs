using Midway.ObjectModel.Exceptions;

namespace Midway.ObjectModel.Extensions
{
    /// <summary>
    /// Расширения для работы со статусом доставки документа
    /// </summary>
    public static class DocumentMultiDeliveryStatusExtensions
    {
        public static DocumentDeliveryStatus ToDocumentDeliveryStatus(this DocumentMultiDeliveryStatus status)
        {
            switch (status)
            {
                case DocumentMultiDeliveryStatus.RecievedByService:
                    return DocumentDeliveryStatus.RecievedByService;
                case DocumentMultiDeliveryStatus.SentToRecipients:
                case DocumentMultiDeliveryStatus.PartlyDeliveredToRecipients:
                    return DocumentDeliveryStatus.SentToRecipient;
                case DocumentMultiDeliveryStatus.NotDeliveredToRecipients:
                    return DocumentDeliveryStatus.NotDeliveredToRecipient;
                case DocumentMultiDeliveryStatus.DeliveredToRecipients:
                    return DocumentDeliveryStatus.DeliveredToRecipient;
                default:
                    throw new ServiceException(ServiceErrorCode.WorkflowViolation, "Некорректный статус доставки документа");
            }
        }
    }
}
