using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// ��������� �������� ������ ���������� � ���������
    /// </summary>
    [DataContract]
    public class FullDocumentInfoRequestParams
    {
        /// <summary>
        /// ����������� �� ���������
        /// </summary>
        public FullDocumentInfoRequestParams()
        {
            this.GetContent = true;
            this.GetCard = true;
            this.GetRelatedDocuments = true;
            this.GetServiceDocuments = true;
            this.GetSigns = true;
        }

        /// <summary>
        /// ��������� ���������� ���������?
        /// </summary>
        [DataMember]
        public bool GetContent { get; set; }

        /// <summary>
        /// ��������� ?
        /// </summary>
        [DataMember]
        public bool GetCard { get; set; }

        /// <summary>
        /// ��������� �������?
        /// </summary>
        [DataMember]
        public bool GetSigns { get; set; }

        /// <summary>
        /// ��������� ��������� ���������?
        /// </summary>
        [DataMember]
        public bool GetServiceDocuments { get; set; }

        /// <summary>
        /// ��������� ��������� ���������?
        /// </summary>
        [DataMember]
        public bool GetRelatedDocuments { get; set; }

        /// <summary>
        /// ���������� ���� ��� ������������ ������� �� ������ ����� �������� �������:
        /// TODO - ��������� ��� �������� � ��� ������?
        /// </summary>
        [DataMember]
        public string UserLogin { get; set; }

        public override string ToString()
        {
            return string.Format("GetContent: {0}, GetCard: {1}, GetSigns: {2}, GetServiceDocuments: {3}, GetRelatedDocuments: {4}", GetContent, GetCard, GetSigns, GetServiceDocuments, GetRelatedDocuments);
        }
    }
}
