namespace Midway.ObjectModel.Exceptions
{
    /// <summary>
    /// ��� ������
    /// </summary>
    public enum ServiceErrorType
    {
        /// <summary>
        /// ������ ��������� ���������
        /// </summary>
        ValidationFormat = 0,
        /// <summary>
        /// ���������� ������ �������
        /// </summary>
        InternalServer = 1,
        /// <summary>
        /// ������ �������� ���������
        /// </summary>
        Delivery
    }
}
