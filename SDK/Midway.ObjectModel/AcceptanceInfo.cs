using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Сведения о приемке.
    /// </summary>
    [DataContract]
    public class AcceptanceInfo : OperationInfo
    {
        /// <summary>
        /// Расширенная информация о содержании операции.
        /// </summary>
        [DataMember]
        public ExtendedOperationDescription ExtendedOperationDescription { get; set; }
    }
}
