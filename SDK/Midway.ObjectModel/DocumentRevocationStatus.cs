using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Статус аннулирования документа
    /// </summary>
    [DataContract]
    public enum DocumentRevocationStatus
    {
        /// <summary>
        /// Еще не было запросов на аннулирование
        /// </summary>
        [EnumMember]
        [Description("Без запроса аннулирования")]
        NoRevocation = 0,

        /// <summary>
        /// Отправлен запрос на аннулирование контрагенту
        /// </summary>
        [EnumMember]
        [Description("Ожидается аннулирование")]
        RevocationAwaited = 1,

        /// <summary>
        /// Получен запрос на аннулирование от контрагента
        /// </summary>
        [EnumMember]
        [Description("Требуется аннулирование")]
        RevocationRequired = 2,

        /// <summary>
        /// Отвергнут запрос на аннулирование
        /// </summary>
        [EnumMember]
        [Description("Отказано в аннулировании")]
        RevocationRejected = 3,

        /// <summary>
        /// Принят запрос на аннулирование
        /// </summary>
        [EnumMember]
        [Description("Принято аннулирование")]
        RevocationAccepted = 4,
    }

}
