namespace Midway.ObjectModel
{
    /// <summary>
    /// ��������� ������ ����������
    /// </summary>
    public class DraftSearchOptions
    {
        /// <summary>
        /// ������ ������� ��������� (������ ������� � ������ ������� ���������, � 0)
        /// </summary>
        public int From { get; set; }

        /// <summary>
        /// ������������ ���������� ������������ ����������
        /// �������� ���� ��������� �������� �� 0 �� 100
        /// </summary>
        public int Max { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string BoxId { get; set; }

        /// <summary>
        /// ��� ���������
        /// </summary>
        public DocumentType? DocumentType { get; set; }
    }
}
