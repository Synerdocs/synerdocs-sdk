using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Тип подписанта документа.
    /// </summary>
    [DataContract]
    public enum SignerType
    {
        /// <summary>
        /// Не указан.
        /// </summary>
        [Description("Не указан")]
        None = 0,

        /// <summary>
        /// Работник организации продавца товаров (работ, услуг, имущественных прав).
        /// </summary>
        [EnumMember]
        [Description("Работник организации продавца товаров (работ, услуг, имущественных прав)")]
        SellerEmployee = 1,

        /// <summary>
        /// Работник организации - составителя файла обмена информации продавца,
        /// если составитель файла обмена информации не является продавцом.
        /// </summary>
        [EnumMember]
        [Description("Работник организации - составителя файла обмена информации продавца," +
            " если составитель файла обмена информации не является продавцом")]
        SellerDrafterEmployee = 2,

        /// <summary>
        /// Работник иной уполномоченной организации.
        /// </summary>
        [EnumMember]
        [Description("Работник иной уполномоченной организации")]
        OtherOrganizationEmployee = 3,

        /// <summary>
        /// Уполномоченное физическое лицо, в том числе ИП.
        /// </summary>
        [EnumMember]
        [Description("Уполномоченное физическое лицо, в том числе ИП")]
        AuthorizedPerson = 4,

        /// <summary>
        /// Работник организации покупателя.
        /// </summary>
        [EnumMember]
        [Description("Работник организации покупателя")]
        BuyerEmployee = 5,

        /// <summary>
        /// Работник организации - составителя файла обмена информации покупателя, 
        /// если составитель файла обмена информации покупателя не является покупателем.
        /// </summary>
        [EnumMember]
        [Description("Работник организации - составителя файла обмена информации покупателя, " +
            "если составитель файла обмена информации покупателя не является покупателем.")]
        BuyerDrafterEmployee = 6
    }
}
