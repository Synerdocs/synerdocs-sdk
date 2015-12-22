using System;

namespace Midway.ObjectModel.Exceptions
{
    /// <summary>
    /// ������ ��������� �������� (��� �������) ���������
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
        /// �������� ����, ��� ��������� �������� �������� ������
        /// </summary>
        public string Field { get; private set; }

        /// <summary>
        /// ��������� �� ������ � �������: ������������ ����, ��� ��������� �� ������
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
