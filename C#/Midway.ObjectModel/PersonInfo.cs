using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// ���������� � ����������� ����
    /// </summary>
    [DataContract]
    public class PersonInfo
    {
        /// <summary>
        /// ���������
        /// </summary>
        [DataMember]
        public string Position { get; set; }

        /// <summary>
        /// ���
        /// </summary>
        [DataMember]
        public string FirstName { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        [DataMember]
        public string LastName { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        [DataMember]
        public string MiddleName { get; set; }
    }
}
