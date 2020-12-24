using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация о подписанте
    /// </summary>
    [DataContract]
    public class SignerInfo
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public SignerInfo()
        {
            OrganizationType = OrganizationType.Unknown;
#pragma warning disable 618 //Отлючить предупреждения насчет устаревших полей (obsolete)
            IsJuridical = false;
#pragma warning restore 618
            Inn = "Не указано";
            StateRegistrationCert = "Не указано";
            Position = "Не указано";
            FirstName = "Не указано";
            LastName = "Не указано";
            MiddleName = "Не указано";
        }

        /// <summary>
        /// Тип организации
        /// </summary>
        [DataMember]
        public OrganizationType OrganizationType { get; set; }

        /// <summary>
        /// Признак, указывающий, что подписант юридическое лицо
        /// </summary>
        [DataMember]
        [Obsolete("Для обеспечения обратной совместимости")]
        public bool IsJuridical { get; set; }

        /// <summary>
        /// ИНН организации
        /// </summary>
        [DataMember]
        public string Inn { get; set; }

        /// <summary>
        /// Должность подписанта
        /// </summary>
        [DataMember]
        public string Position { get; set; }

        /// <summary>
        /// Свидетельство государственной регистрации ИП
        /// </summary>
        [DataMember]
        public string StateRegistrationCert { get; set; }

        /// <summary>
        /// Фамилия подписанта
        /// </summary>
        [DataMember]
        public string FirstName { get; set; }

        /// <summary>
        /// Имя подписанта
        /// </summary>
        [DataMember]
        public string LastName { get; set; }

        /// <summary>
        /// Отчество подписанта
        /// </summary>
        [DataMember]
        public string MiddleName { get; set; }
    }
}