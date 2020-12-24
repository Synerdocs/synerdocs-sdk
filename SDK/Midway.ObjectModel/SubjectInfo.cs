using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация о субъекте электронного документооборота
    /// </summary>
    [DataContract]
    public class SubjectInfo
    {
        /// <summary>
        /// Тип организации
        /// </summary>
        [DataMember]
        public OrganizationType OrganizationType { get; set; }

        /// <summary>
        /// Признак, указывающий что субъект - юридическое лицо
        /// </summary>
        [DataMember]
        [Obsolete("Для обеспечения обратной совместимости")]
        public bool IsJuridical { get; set; }

        /// <summary>
        /// Признак, указывающий что субъект - спецоператор ЭДО
        /// </summary>
        [DataMember]
        public bool IsOperator { get; set; }

        /// <summary>
        /// Сервисный код участника ЭДО
        /// </summary>
        [DataMember]
        public string ServiceCode { get; set; }

        /// <summary>
        /// Сервисный код оператора ЭДО
        /// </summary>
        [DataMember]
        public string OperatorServiceCode { get; set; }

        /// <summary>
        /// ИНН организации
        /// </summary>
        [DataMember]
        public string Inn { get; set; }

        /// <summary>
        /// КПП организации
        /// </summary>
        [DataMember]
        public string Kpp { get; set; }

        /// <summary>
        /// Наименование организации
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Имя (для ИП)
        /// </summary>
        [DataMember]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия (для ИП)
        /// </summary>
        [DataMember]
        public string LastName { get; set; }

        /// <summary>
        /// Отчество (для ИП)
        /// </summary>
        [DataMember]
        public string MiddleName { get; set; }
    }
}
