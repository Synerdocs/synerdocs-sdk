using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// ���������� � ������������� ������ �����������
    /// </summary>
    [DataContract]
    public class EncryptedTokenInfo
    {
        /// <summary>
        /// ������������� ������ � ��
        /// </summary>
        [DataMember]
        public string TokenId { get; set; }

        /// <summary>
        /// ������������� ����� � base64 ���������
        /// </summary>
        [DataMember]
        public string EncryptedToken { get; set; }

        /// <summary>
        /// ����� ������������
        /// </summary>
        [DataMember]
        public string Login { get; set; }
    }
}
