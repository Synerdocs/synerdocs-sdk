using System;
using System.ComponentModel;
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
        public ObjectModel.EnhancedSignCreateStatus CreateStatus { get; set; }

        /// <summary>
        /// Усовершенствованная подпись
        /// </summary>
        [DataMember]
        public byte[] Raw { get; set; }

        /// <summary>
        /// Информация об ошибке
        /// </summary>
        [DataMember]
        public ObjectModel.EnhancingSignFailedInfo FailedInfo { get; set; }

        /// <summary>
        /// Время, к которому будет готова 
        /// усовершенствованная подпись
        /// </summary>
        [DataMember]
        public DateTime CreateTime { get; set; }
    }

    /// <summary>
    /// Статус создания усовершенствованной подписи
    /// </summary>
    [DataContract]
    [Flags]
    public enum EnhancedSignCreateStatus
    {
        /// <summary>
        /// Усовершенствованная подпись находится в процессе создания
        /// </summary>
        [EnumMember]
        [Description("Усовершенствованная подпись находится в процессе создания")]
        InProgress = 0x00,

        /// <summary>
        /// Усовершенствованная подпись создана
        /// </summary>
        [EnumMember]
        [Description("Усовершенствованная подпись создана")]
        Success = 0x01,

        /// <summary>
        /// Не удалось создать усовершенствованную подпись
        /// </summary>
        [EnumMember]
        [Description("Не удалось создать усовершенствованную подпись")]
        Failed = 0x02
    }

    /// <summary>
    /// Причины неудачной попытки создания 
    /// усовершенствованной подписи
    /// </summary>
    [DataContract]
    [Flags]
    public enum EnhancedSignFailedReason
    {
        /// <summary>
        /// Сертификат подписанта отозван
        /// </summary>
        [EnumMember]
        [Description("Сертификат подписанта отозван")]
        SignerCertificateIsRevoked = 0x01,

        /// <summary>
        /// Один из промежуточных 
        /// сертификатов цепочки доверия отозван
        /// </summary>
        [EnumMember]
        [Description("Один из промежуточных сертификатов цепочки доверия отозван")]
        OtherCertificateIsRevoked = 0x02,

        /// <summary>
        /// Недоступны источники списков 
        /// отзыва или OCSP-сервис
        /// </summary>
        [EnumMember]
        [Description("Недоступны источники списков отзыва или OCSP-сервис")]
        RevocationInfoUnavailable = 0x03,

        /// <summary>
        /// Прочие причины, по которым невозможно 
        /// создание усовершенствованной подписи
        /// </summary>
        [EnumMember]
        [Description("Прочие причины, по которым невозможно создание усовершенствованной подписи")]
        Other = 0x04
    }

    /// <summary>
    /// Информация об ошибке, возникшей при 
    /// попытке создания усовершенствованной подписи
    /// </summary>
    [DataContract]
    public class EnhancingSignFailedInfo
    {
        /// <summary>
        /// Причина
        /// </summary>
        [DataMember]
        public ObjectModel.EnhancedSignFailedReason Reason { get;  set; }

        /// <summary>
        /// Соббщение об ошибке
        /// </summary>
        [DataMember]
        public string Message { get;  set; }
    }
}
