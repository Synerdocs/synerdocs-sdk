using System;

namespace Midway.ObjectModel.Exceptions
{
    /// <summary>
    /// Ошибки валидации входящих (для сервиса) сообщений
    /// </summary>
    public class ValidationException : ServiceException
    {
        public ValidationException(ServiceErrorCode serviceErrorCode, string field)
            : base(serviceErrorCode)
        {
            Field = field;
        }

        public ValidationException(ServiceErrorCode serviceErrorCode, string field, string message)
            : base(serviceErrorCode, message)
        {
            Field = field;
        }

        public ValidationException(ServiceErrorCode serviceErrorCode, string field, string message, Exception innerException)
            : base(serviceErrorCode, message, innerException)
        {
            Field = field;
        }

        /// <summary>
        /// Название поля, при валидации которого возникла ошибка
        /// </summary>
        public string Field { get; private set; }

        /// <summary>
        /// Сообщение об ошибке в формате: наименование поля, код сообщения об ошибке
        /// </summary>
        public override string Message
        {
            get
            {
                return string.Format("Field: {0}, {1}", Field, base.Message);
            }
        }

    }
}
