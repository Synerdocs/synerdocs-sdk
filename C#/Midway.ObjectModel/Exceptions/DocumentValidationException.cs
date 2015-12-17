using System;

namespace Midway.ObjectModel.Exceptions
{
    /// <summary>
    /// Ошибки валидации документа
    /// </summary>
    public class DocumentValidationException : ServiceException
    {
        public DocumentValidationException(ServiceErrorCode serviceErrorCode)
            : base(serviceErrorCode)
        {
        }

        public DocumentValidationException(ServiceErrorCode serviceErrorCode, string message)
            : base(serviceErrorCode, message)
        {
        }

        public DocumentValidationException(ServiceErrorCode serviceErrorCode, string message, Exception innerException)
            : base(serviceErrorCode, message, innerException)
        {
        }
    }
}
