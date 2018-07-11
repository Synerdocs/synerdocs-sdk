using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Представитель контрагента.
    /// </summary>
    [DataContract]
    public class CounterpartyRepresentative
    {
        /// <summary>
        /// ФИО.
        /// </summary>
        [DataMember]
        public FullName FullName { get; set; }

        /// <summary>
        /// Должность представителя организации.
        /// </summary>
        [DataMember]
        public string Position { get; set; }

        /// <summary>
        /// Основание полномочий (доверия) представителя организаций.
        /// </summary>
        [DataMember]
        public string AuthorityBase { get; set; }

        /// <summary>
        /// Иные сведения о представителе организации.
        /// </summary>
        [DataMember]
        public string AdditionalInfo { get; set; }
    }
}
