using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// ������ ������ � ������. ������������ ��� �������� ����������� ����� � ������.
    /// </summary>
    [DataContract]
    public class NamedContent
    {
        /// <summary>
        /// ��������
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// �����������
        /// </summary>
        [DataMember]
        public byte[] Content { get; set; }
    }
}