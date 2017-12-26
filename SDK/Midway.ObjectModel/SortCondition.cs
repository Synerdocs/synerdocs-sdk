using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Условие сортировки.
    /// </summary>
    [DataContract]
    public class SortCondition
    {
        /// <summary>
        /// Наименование поля.
        /// </summary>
        [DataMember(IsRequired = true)]
        public EnumValue FieldName { get; set; }

        /// <summary>
        /// <c>true</c>, если требуется сортировать по убыванию, иначе <c>false</c>.
        /// </summary>
        [DataMember]
        public bool Descending { get; set; }
    }
}
