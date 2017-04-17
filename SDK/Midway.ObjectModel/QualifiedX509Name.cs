using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Представление информации из поля Subject сертификата
    /// </summary>
    [DataContract]
    public class QualifiedX509Name : X509NameInfo
    {
        /// <summary>
        /// Тип ЮЛ/ИП
        /// </summary>
        [DataMember]
        public EnumValue Type { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [DataMember]
        public string LastName { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [DataMember]
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        [DataMember]
        public string MiddleName { get; set; }

        /// <summary>
        /// Двухбуквенный код страны
        /// </summary>
        [DataMember]
        public string CountryCode { get; set; }

        /// <summary>
        /// Регион РФ
        /// </summary>
        [DataMember]
        public NameCodeObject Region { get; set; }

        /// <summary>
        /// Индекс
        /// </summary>
        [DataMember]
        public string PostalCode { get; set; }

        /// <summary>
        /// Город (Населенный пункт)
        /// </summary>
        [DataMember]
        public string Location { get; set; }

        /// <summary>
        /// Улица
        /// </summary>
        [DataMember]
        public string Street { get; set; }

        /// <summary>
        /// /Дом
        /// </summary>
        [DataMember]
        public string House { get; set; }

        /// <summary>
        /// Корпус
        /// </summary>
        [DataMember]
        public string Building { get; set; }

        /// <summary>
        /// Квартира
        /// </summary>
        [DataMember]
        public string Apartment { get; set; }

        /// <summary>
        /// Наименование подразделения
        /// </summary>
        [DataMember]
        public string Department { get; set; }

        /// <summary>
        /// КПП
        /// </summary>
        [DataMember]
        public string Kpp { get; set; }

        /// <summary>
        /// СНИЛС
        /// </summary>
        [DataMember]
        public string Snils { get; set; }

        /// <summary>
        /// ИФНС
        /// </summary>
        [DataMember]
        public string Ifns { get; set; }
    }
}
