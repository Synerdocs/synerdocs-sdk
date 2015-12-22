using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Краткая информация об организации. 
    /// Структура данных для передачи ИНН, КПП и наименования организации
    /// </summary>
    [DataContract]
    public class InnKppName
    {
        /// <summary>
        /// ИНН
        /// </summary>
        [DataMember]
        public string Inn { get; set; }

        /// <summary>
        /// КПП
        /// </summary>
        [DataMember]
        public string Kpp { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}