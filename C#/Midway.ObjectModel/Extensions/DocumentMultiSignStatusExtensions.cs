using Midway.ObjectModel.Exceptions;

namespace Midway.ObjectModel.Extensions
{
    /// <summary>
    /// Расширения для работы со статусом документа
    /// </summary>
    public static class DocumentMultiSignStatusExtensions
    {
        /// <summary>
        /// Преобразование типа из DocumentMultiSignStatus в DocumentSignStatus
        /// </summary>
        /// <param name="status">Статус документа типа DocumentMultiSignStatus</param>
        /// <returns>Статус документа типа DocumentSignStatus</returns>
        public static DocumentSignStatus ToDocumentSignStatus(this DocumentMultiSignStatus status)
        {
            switch (status)
            {
                case DocumentMultiSignStatus.NoSignNeeded:
                    return DocumentSignStatus.NoSignNeeded;
                case DocumentMultiSignStatus.WaitingForSign:
                case DocumentMultiSignStatus.PartlySigned:
                    return DocumentSignStatus.WaitingForSign;
                case DocumentMultiSignStatus.SignRejected:
                    return DocumentSignStatus.SignRejected;
                case DocumentMultiSignStatus.Signed:
                    return DocumentSignStatus.Signed;
                default:
                    throw new ServiceException(ServiceErrorCode.WorkflowViolation, "Некорректный статус подписания документа");
            }
        }
    }
}
