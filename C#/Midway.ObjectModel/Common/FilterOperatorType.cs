using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel.Common
{
    /// <summary>
    /// Тип оператора фильтра
    /// </summary>
//    [DataContract]
    public enum FilterOperatorType
    {
        /// <summary>
        /// Не установлен
        /// </summary>
        [Description("Не установлен")]
        None = 0,

        /// <summary>
        /// Равно
        /// </summary>
        [EnumMember]
        [Description("Равно")]
        Equals = 1,

        /// <summary>
        /// Не равно
        /// </summary>
        [EnumMember]
        [Description("Не равно")]
        NotEquals = 2,

        /// <summary>
        /// Больше
        /// </summary>
        [EnumMember]
        [Description("Больше")]
        Greater = 3,

        /// <summary>
        /// Меньше
        /// </summary>
        [EnumMember]
        [Description("Меньше")]
        Less = 4,

        /// <summary>
        /// Больше или равно
        /// </summary>
        [EnumMember]
        [Description("Больше или равно")]
        GreaterOrEquals = 5,

        /// <summary>
        /// Меньше или равно
        /// </summary>
        [EnumMember]
        [Description("Меньше или равно")]
        LessOrEquals = 6,

        /// <summary>
        /// Содержит
        /// </summary>
        [EnumMember]
        [Description("Содержит")]
        Contains = 7,

        /// <summary>
        /// Не содержит
        /// </summary>
        [EnumMember]
        [Description("Не содержит")]
        NotContains = 8,

        /// <summary>
        /// Находится в перечислении
        /// </summary>
        [EnumMember]
        [Description("Находится в перечислении")]
        In = 9,

        /// <summary>
        /// Не находится в перечислении
        /// </summary>
        [EnumMember]
        [Description("Не находится в перечислении")]
        NotIn = 10,

        /// <summary>
        /// Равно полю
        /// </summary>
        [EnumMember]
        [Description("Равно полю")]
        EqualsField = 11,

        /// <summary>
        /// Не равно полю
        /// </summary>
        [EnumMember]
        [Description("Не равно полю")]
        NotEqualsField = 12,

        /// <summary>
        /// Больше поля
        /// </summary>
        [EnumMember]
        [Description("Больше поля")]
        GreaterField = 13,

        /// <summary>
        /// Меньше поля
        /// </summary>
        [EnumMember]
        [Description("Меньше поля")]
        LessField = 14,

        /// <summary>
        /// Больше или равно полю
        /// </summary>
        [EnumMember]
        [Description("Больше или равно полю")]
        GreaterOrEqualsField = 15,

        /// <summary>
        /// Меньше или равно полю
        /// </summary>
        [EnumMember]
        [Description("Меньше или равно полю")]
        LessOrEqualsField = 16,

        /// <summary>
        /// Пустое
        /// </summary>
        [EnumMember]
        [Description("Пустое")]
        IsNull = 17,

        /// <summary>
        /// Не пустое
        /// </summary>
        [EnumMember]
        [Description("Не пустое")]
        IsNotNull = 18,
    }
}
