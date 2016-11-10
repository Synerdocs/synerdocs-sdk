using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Банковские реквизиты
    /// </summary>
    [DataContract]
    public class BankAccount
    {
        /// <summary>
        /// Информация о банке
        /// </summary>
        [DataMember]
        public Bank Bank { get; set; }

        /// <summary>
        /// Расчетный счет
        /// </summary>
        [DataMember]
        public string PaymentAccount { get; set; }

        /// <summary>
        /// Корреспондентский счет
        /// </summary>
        [DataMember]
        public string CorrespondentAccount { get; set; }
    }
}
