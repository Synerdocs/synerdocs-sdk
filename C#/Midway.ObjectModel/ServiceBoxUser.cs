namespace Midway.ObjectModel
{
    //TODO ����� �� ������������, ������ �� ���� ����, �� �� ����� �� ������������
    /// <summary>
    /// ���������� � ������������ �����
    /// ����� �� ������������
    /// </summary>
    public class ServiceBoxUser
    {
        /// <summary>
        /// ����� ������������
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// ����� ������������ (��������, �����������, e-mail?)
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// ���
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public string MiddleName { get; set; }
    }
}
