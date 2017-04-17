using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Основная информация о подразделении
    /// </summary>
    [DataContract]
    public class DepartmentShortInfo
    {
        /// <summary>
        /// Идентификатор подразделения
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// Идентификатор родительского подразделения. 
        /// Null для головного подразделения.
        /// </summary>
        [DataMember]
        public string ParentId { get; set; }

        /// <summary>
        /// Наименование подразделения
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Код подразделения
        /// </summary>
        [DataMember]
        public string Code { get; set; }

        /// <summary>
        /// КПП (для филиалов)
        /// </summary>
        [DataMember]
        public string Kpp { get; set; }

        /// <summary>
        /// Дополнительная информация, примечание
        /// </summary>
        [DataMember]
        public string AdditionalInfo { get; set; }
    }
}
