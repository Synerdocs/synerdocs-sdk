using System;

namespace Midway.ObjectModel.Exceptions
{
    public class ServiceException : Exception
    {
        private ServiceErrorCode serviceErrorCode;

        public ServiceException(ServiceErrorCode serviceErrorCode):base()
        {
            this.serviceErrorCode = serviceErrorCode;
        }

        public ServiceException(ServiceErrorCode serviceErrorCode, string message):base(message)
        {
            this.serviceErrorCode = serviceErrorCode;
        }

        public ServiceException(ServiceErrorCode serviceErrorCode, string message, Exception innerException) : base(message, innerException)
        {
            this.serviceErrorCode = serviceErrorCode;
        }

        public ServiceErrorCode ServiceErrorCode
        {
            get { return serviceErrorCode; }
        }

        public override string Message
        {
            get
            {
                return string.Format("Code: {0}, {1}", ServiceErrorCode, base.Message);
            }
        }

        public string ServiceMessage
        {
            get { return base.Message; }
        }

    }
}
