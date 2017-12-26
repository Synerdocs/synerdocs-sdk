using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Усовершенствованная подпись
    /// </summary>
    [DataContract]
    public class EnhancedSign
    {
        /// <summary>
        /// Статус создания усовершенствованной подписи
        /// </summary>
        [DataMember]
        public EnhancedSignCreateStatus CreateStatus { get; set; }

        /// <summary>
        /// Усовершенствованная подпись
        /// </summary>
        [DataMember]
        public byte[] Raw { get; set; }

        /// <summary>
        /// Информация об ошибке
        /// </summary>
        [DataMember]
        public EnhancingSignFailedInfo FailedInfo { get; set; }

        /// <summary>
        /// Время, к которому будет готова 
        /// усовершенствованная подпись
        /// </summary>
        [DataMember]
        public DateTime CreateTime { get; set; }
    }
}
