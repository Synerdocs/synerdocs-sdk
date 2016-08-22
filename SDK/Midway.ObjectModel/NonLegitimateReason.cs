using System.ComponentModel;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Причины нелегитимности документа
    /// </summary>
    public enum NonLegitimateReason
    {
        /// <summary>
        /// Причина отсутствует (документ легитимен)
        /// </summary>
        [Description("Документ легитимен")]
        NoReason = 0x00000000,

        /// <summary>
        /// Отправитель не принял Правила работы в сервисе
        /// </summary>
        [Description("Отправитель не принял Правила работы в сервисе")]
        SenderNotAccepted = 0x00000001,

        /// <summary>
        /// Отправитель не принял регламент обмена ЭСФ
        /// </summary>
        [Description("Отправитель не принял регламент обмена ЭСФ")]
        SenderNotAcceptedInvoice = 0x00000002,

        /// <summary>
        /// Получатель не принял Правила работы в сервисе
        /// </summary>
        [Description("Получатель не принял Правила работы в сервисе")]
        ReceiverNotAccepted = 0x00000004,

        /// <summary>
        /// Получатель не принял регламент ЭСФ
        /// </summary>
        [Description("Получатель не принял регламент ЭСФ")]
        ReceiverNotAcceptedInvoice = 0x00000008,

        /// <summary>
        /// Пользователь (отправитель) не принял регламент ЭСФ
        /// </summary>
        [Description("Отправитель не принял регламент ЭСФ")]
        SenderUserNotAcceptedInvoice = 0x00000010,

        /// <summary>
        /// Родительский документ нелегитимен
        /// </summary>
        [Description("Родительский документ нелегитимен")]
        ParentDocumentNotLegitimate = 0x00000020,

        /// <summary>
        /// Сертификат подписанта не соответствует ФЗ-63
        /// </summary>
        [Description("Сертификат подписанта не соответствует ФЗ-63")]
        SignerCertificateIsNotQualified = 0x00000040,

        /// <summary>
        /// Сертификат подписанта является демонстрационным
        /// </summary>
        [Description("Сертификат подписанта является демонстрационным")]
        SignerCertificateIsDemo = 0x00000080,
    }
}
