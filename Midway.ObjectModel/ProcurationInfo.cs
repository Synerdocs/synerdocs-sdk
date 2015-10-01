using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация о доверенности
    /// </summary>
    [DataContract]
    public class ProcurationInfo
    {
        /// <summary>
        /// Номер доверенности
        /// </summary>
        [DataMember]
        public string Num { get; set; }

        /// TODO: почему не DateTime?
        /// <summary>
        /// Дата выдачи доверенности
        /// </summary>
        [DataMember]
        public string Date { get; set; }

        /// <summary>
        /// Наименование организации доверителя
        /// </summary>
        [DataMember]
        public string NameOrgMandator { get; set; }

        /// <summary>
        /// Дополнительная информация
        /// </summary>
        [DataMember]
        public string MoreInfo { get; set; }

        /// <summary>
        /// Доверитель
        /// </summary>
        [DataMember]
        public PersonInfo Mandator { get; set; }

        /// <summary>
        /// Доверенное лицо
        /// </summary>
        [DataMember]
        public PersonInfo Confidant { get; set; }
    }
}
