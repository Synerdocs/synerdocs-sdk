using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Опции генерации транспортной накладной.
    /// </summary>
    [DataContract]
    public class TransportWaybillGenerationOptions
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
        /// Ящик организации-перевозчика.
        /// </summary>
        [DataMember]
        public string CarrierBoxId { get; set; }

        /// <summary>
        /// Ящик организации-водителя.
        /// </summary>
        [DataMember]
        public string DriverBoxId { get; set; }

        /// <summary>
        /// Ящик организации-грузополучателя.
        /// </summary>
        [DataMember]
        public string ConsigeeBoxId { get; set; }

        /// <summary>
        /// Тип участника-отправителя титула транспортной накладной.
        /// </summary>
        [DataMember]
        public EnumValue TitleSenderType { get; set; }
    }
}
