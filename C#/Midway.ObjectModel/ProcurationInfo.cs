using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// ���������� � ������������
    /// </summary>
    [DataContract]
    public class ProcurationInfo
    {
        /// <summary>
        /// ����� ������������
        /// </summary>
        [DataMember]
        public string Num { get; set; }

        /// TODO: ������ �� DateTime?
        /// <summary>
        /// ���� ������ ������������
        /// </summary>
        [DataMember]
        public string Date { get; set; }

        /// <summary>
        /// ������������ ����������� ����������
        /// </summary>
        [DataMember]
        public string NameOrgMandator { get; set; }

        /// <summary>
        /// �������������� ����������
        /// </summary>
        [DataMember]
        public string MoreInfo { get; set; }

        /// <summary>
        /// ����������
        /// </summary>
        [DataMember]
        public PersonInfo Mandator { get; set; }

        /// <summary>
        /// ���������� ����
        /// </summary>
        [DataMember]
        public PersonInfo Confidant { get; set; }
    }
}
