using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// ������� ���������� �� �����������. 
    /// ��������� ������ ��� �������� ���, ��� � ������������ �����������
    /// </summary>
    [DataContract]
    public class InnKppName
    {
        /// <summary>
        /// ���
        /// </summary>
        [DataMember]
        public string Inn { get; set; }

        /// <summary>
        /// ���
        /// </summary>
        [DataMember]
        public string Kpp { get; set; }

        /// <summary>
        /// ������������
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}