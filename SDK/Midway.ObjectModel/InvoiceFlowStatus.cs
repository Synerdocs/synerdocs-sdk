using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// TODO Этого набора не достаточно для того-чтобы предотвращать повторную отправку служебных документов
    /// <summary>
    /// Статусы ЭСФ
    /// </summary>
    [DataContract]
    public enum InvoiceFlowStatus
    {
        /// <summary>
        /// ЭСФ отправлен (это начальный статус после того как ЭСФ был отправлен через сервис)
        /// </summary>
        [EnumMember]
        InvoiceSent = 0x0,

        /// <summary>
        /// ЭСФ выставлен (получены все необходимые СД)
        /// </summary>
        [EnumMember]
        InvoiceCharged = 0x1,

        /// <summary>
        /// ЭСФ отклонен (отправлен запрос на уточнение)
        /// </summary>
        [EnumMember]
        InvoiceRejected = 0x2,

        /// <summary>
        /// ЭСФ недействителен (в течении 3х суток не высланы все необходимые СД)
        /// </summary>
        [EnumMember]
        InvoiceNotValid = 0x3,
    }
}