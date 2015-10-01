using System.Runtime.Serialization;

namespace Midway.ObjectModel.Common
{
    /// <summary>
    /// Настройка сортировки
    /// </summary>
    [DataContract]
    public class SortingSetting
    {
        /// <summary>
        /// Номер по порядку
        /// </summary>
        [DataMember]
        public int PositionNumber { get; set; }

        /// <summary>
        /// Поле, по которому производится сортировка
        /// </summary>
        [DataMember]
        public string FieldName { get; set; }

        /// <summary>
        /// Признак сортировки по возрастанию
        /// </summary>
        [DataMember]
        public bool Asc { get; set; }
    }
}
