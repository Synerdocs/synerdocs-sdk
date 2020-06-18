using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на перевыпуск QR-кода.
    /// </summary>
    [DataContract]
    public class ReissueCertificateQrCodeRequest
    {
        /// <summary>
        /// Номер телефона для получения кода активации 
        /// (если не указывать, то будет использован номер из заявки на выпуск сертификата).
        /// </summary>
        [DataMember(IsRequired = false)]
        public string MobilePhoneNumber { get; set; }

        /// <summary>
        /// ИД сотрудника
        /// (если не указывать, то будет использован ИД текущего сотрудника).
        /// </summary>
        [DataMember(IsRequired = false)]
        public string EmployeeId { get; set; }
    }
}
