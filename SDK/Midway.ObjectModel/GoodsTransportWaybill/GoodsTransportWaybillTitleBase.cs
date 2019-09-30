using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Базовый класс товарно-транспортной накладной.
    /// </summary>
    [DataContract]
    public abstract class GoodsTransportWaybillTitleBase
    {
        /// <summary>
        /// ИД файла - имя сформированного файла (без расширения).
        /// </summary>
        [DataMember]
        public string FileId { get; set; }

        /// <summary>
        /// Версия формата товарно-транспортной накладной.
        /// </summary>
        [DataMember(IsRequired = true)]
        public EnumValue FormatVersion { get; set; }
    }
}
