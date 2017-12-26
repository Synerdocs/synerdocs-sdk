using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Ответ при получении настройки.
    /// </summary>
    [DataContract]
    public class SettingGettingResponse : OperationResponse
    {
        /// <summary>
        /// Значение настройки.
        /// </summary>
        [DataMember]
        public SettingValue SettingValue { get; set; }
    }
}
