using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Валюта
    /// </summary>
    [DataContract]
    public class CurrencyInfo
    {
        /// <summary>
        /// Наименование и код валюты
        /// </summary>
        [DataMember]
        public NameCodeObject Currency { get; set; }

        /// <summary>
        /// Курс валюты
        /// </summary>
        [DataMember]
        public decimal? CurrencyRate { get; set; }
    }
}
