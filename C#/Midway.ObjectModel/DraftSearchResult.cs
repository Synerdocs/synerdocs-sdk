namespace Midway.ObjectModel
{
    /// <summary>
    /// ��������� ������ ����������
    /// </summary>
    public class DraftSearchResult
    {
        /// <summary>
        /// ����� ���������� ������� �� ����������� ������
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// ��������� ���������
        /// </summary>
        public DraftSearchItem[] Items { get; set; }
    }
}
