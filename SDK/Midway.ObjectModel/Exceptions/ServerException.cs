using System;
using System.ComponentModel;

namespace Midway.ObjectModel.Exceptions
{
    /// <summary>
    /// Ошибка сервиса обмена
    /// </summary>
    public class ServerException : Exception
    {
        private readonly ServiceErrorCode _code;
        private readonly string _field;
        private readonly string _serviceStackTrace;

        #region Конструкторы

        public ServerException(ServiceErrorCode code)
            : base()
        {
            _code = code;
        }

        public ServerException(ServiceErrorCode code, string field, string message)
            : base(message)
        {
            _code = code;
            _field = field;
        }

        public ServerException(ServiceErrorCode code, string field, string message, string serviceStackTrace)
            : base(message)
        {
            _code = code;
            _field = field;
            _serviceStackTrace = serviceStackTrace;
        }

        public ServerException(ServiceErrorCode code, string field, string message, string serviceStackTrace, Exception innerException)
            : base(message, innerException)
        {
            _code = code;
            _field = field;
            _serviceStackTrace = serviceStackTrace;
        }

        #endregion Конструкторы


        public ServiceErrorCode Code
        {
            get { return _code; }
        }

        public string CodeName
        {
            get
            {
                // поскольку сборка Midway.Legacy.Common здесь недоступна, пришлось продублировать код Midway.Legacy.Common.Utils.GetDescription<TEnum>()
                var fi = Code.GetType().GetField(Code.ToString());

                var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                return (attributes.Length > 0) 
                    ? attributes[0].Description 
                    : Code.ToString();
            }
        }

        public string Field
        {
            get { return _field; }
        }

        public string ServiceStackTrace
        {
            get { return _serviceStackTrace; }
        }

        public string FullMessage
        {
            get
            {
                return string.Format("Code: {0}, Field: {1}, Message: {2}, ServiceStackTrace: {3}", _code, _field, Message, _serviceStackTrace);
            }
        }
    }
}
