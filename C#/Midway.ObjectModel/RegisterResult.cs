using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    [DataContract]
    public class RegisterResult
    {
        /// <summary>
        /// �����������
        /// </summary>
        public RegisterResult()
        {
            ErrorMessages = new List<string>(); 
            ErrorMembers = new List<string>();
        }

        /// <summary>
        /// ������������������ ������������
        /// </summary>
        [DataMember]
        public RegisterModel RegisterModel { get; set; }

        /// <summary>
        /// ������ ��� �����������. ��������� ����� ���� ������, �� ������� �� ����� null.
        /// </summary>
        [DataMember]
        //TODO �����������!
        public List<string> ErrorMessages { get; set; }

        /// <summary>
        /// �������� ��������� ���� ������, �� ��������� ���������. ��������� ����� ���� ������, �� ������� �� ����� null.
        /// </summary>
        [DataMember]
        public List<string> ErrorMembers { get; set; }

        /// <summary>
        /// ��������� �����������. 
        /// ���� ����������� ������ �������, �� ���������� true, ����� ���������� false
        /// </summary>
        [DataMember]
        public bool Success { get; set; }
    }
}