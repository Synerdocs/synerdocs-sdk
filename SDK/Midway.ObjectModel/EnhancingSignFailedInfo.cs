using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация об ошибке, возникшей при 
    /// попытке создания усовершенствованной подписи.
    /// </summary>
    [DataContract]
    public class EnhancingSignFailedInfo
    {
        /// <summary>
        /// Причина.
        /// </summary>
        [DataMember]
        public EnhancedSignFailedReason Reason { get; set; }

        /// <summary>
        /// Соббщение об ошибке.
        /// </summary>
        [DataMember]
        public string Message { get; set; }
    }
}
