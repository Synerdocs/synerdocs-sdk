using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Данные сотрудника, являющегося подписантом простой ЭП.
    /// </summary>
    [DataContract]
    public class SimpleSignatureEmployee
    {
        /// <summary>
        /// Должность.
        /// </summary>
        [DataMember]
        public string Position { get; set; }

        /// <summary>
        /// E-mail.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Email { get; set; }

        /// <summary>
        /// СНИЛС.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Snils { get; set; }

        /// <summary>
        /// ФИО.
        /// </summary>
        [DataMember(IsRequired = true)]
        public FullName FullName { get; set; }
    }
}
