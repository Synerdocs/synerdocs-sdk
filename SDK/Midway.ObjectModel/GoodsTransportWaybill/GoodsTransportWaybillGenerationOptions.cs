using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Опции генерации товарно-транспортной накладной.
    /// </summary>
    [DataContract]
    public class GoodsTransportWaybillGenerationOptions
    {
        /// <summary>
        /// Требуется ли валидация контента.
        /// </summary>
        [DataMember]
        public bool ValidateContent { get; set; }

        /// <summary>
        /// Ящик организации-грузоотправителя.
        /// </summary>
        [DataMember]
        public string ConsignorBoxId { get; set; }

        /// <summary>
        /// Ящик организации-грузополучателя.
        /// </summary>
        [DataMember]
        public string ConsigeeBoxId { get; set; }
    }
}
