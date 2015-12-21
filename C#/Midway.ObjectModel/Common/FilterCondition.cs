using System.Runtime.Serialization;

namespace Midway.ObjectModel.Common
{
    /// <summary>
    /// Условие фильтра
    /// </summary>
//    [DataContract]
    public class FilterCondition
    {
        /// <summary>
        /// Номер по порядку
        /// </summary>
        [DataMember]
        public int PositionNumber { get; set; }

        /// <summary>
        /// Правило присоединения условия фильтра (И/ИЛИ)
        /// И = true; ИЛИ = false
        /// </summary>
        [DataMember]
        public bool AndOr { get; set; }

        /// <summary>
        /// Кол-во открывающихся скобок перед условием фильтра
        /// </summary>
        [DataMember]
        public int OpeningBracketsCount { get; set; }

        /// <summary>
        /// Кол-во закрывающихся скобок после условия фильтра
        /// </summary>
        [DataMember]
        public int ClosingBracketsCount { get; set; }

        /// <summary>
        /// Наименование поля
        /// </summary>
        [DataMember]
        public string FieldName { get; set; }

        /// <summary>
        /// Тип оператора
        /// </summary>
        [DataMember]
        public FilterOperatorType Operator { get; set; }

        /// <summary>
        /// Значение
        /// </summary>
        [DataMember]
        public string Value { get; set; }
    }
}
