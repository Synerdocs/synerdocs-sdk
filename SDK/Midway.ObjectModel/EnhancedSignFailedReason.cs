using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Причины неудачной попытки создания 
    /// усовершенствованной подписи.
    /// </summary>
    [DataContract]
    [Flags]
    public enum EnhancedSignFailedReason
    {
        /// <summary>
        /// Сертификат подписанта отозван.
        /// </summary>
        [EnumMember]
        [Description("Сертификат подписанта отозван")]
        SignerCertificateIsRevoked = 0x01,

        /// <summary>
        /// Один из промежуточных 
        /// сертификатов цепочки доверия отозван.
        /// </summary>
        [EnumMember]
        [Description("Один из промежуточных сертификатов цепочки доверия отозван")]
        OtherCertificateIsRevoked = 0x02,

        /// <summary>
        /// Недоступны источники списков 
        /// отзыва или OCSP-сервис.
        /// </summary>
        [EnumMember]
        [Description("Недоступны источники списков отзыва или OCSP-сервис")]
        RevocationInfoUnavailable = 0x03,

        /// <summary>
        /// Прочие причины, по которым невозможно 
        /// создание усовершенствованной подписи.
        /// </summary>
        [EnumMember]
        [Description("Прочие причины, по которым невозможно создание усовершенствованной подписи")]
        Other = 0x04
    }
}
