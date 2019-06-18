using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Вид средств.
    /// </summary>
    [DataContract]
    public enum FundsType
    {
        /// <summary>
        /// Средства бюджета.
        /// </summary>
        [EnumMember]
        [Description("Средства бюджета")]
        Budget = 1,

        /// <summary>
        /// Средства дополнительного бюджетного финансирования.
        /// </summary>
        [EnumMember]
        [Description("Средства дополнительного бюджетного финансирования")]
        AdditionalBudget = 2,

        /// <summary>
        /// Средства для финансирования мероприятий по оперативно-розыскной деятельности.
        /// </summary>
        [EnumMember]
        [Description("Средства для финансирования мероприятий по оперативно-розыскной деятельности")]
        InvestigationFunds = 3,

        /// <summary>
        /// Средства, поступающие во временное распоряжение казенных учреждений.
        /// </summary>
        [EnumMember]
        [Description("Средства, поступающие во временное распоряжение казенных учреждений")]
        TemporaryFunds = 4,

        /// <summary>
        /// Средства юр. лиц. Источник средств, за счет которого должна быть произведена кассовая выплата.
        /// </summary>
        [EnumMember]
        [Description("Средства юр. лиц. Источник средств, за счет которого должна быть произведена кассовая выплата")]
        LegalEntityFunds = 5
    }
}
