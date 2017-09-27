using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Реквизиты простой ЭП.
    /// </summary>
    [DataContract]
    public class SimpleSignatureRequisites
    {
        /// <summary>
        /// Организация подписанта.
        /// </summary>
        [DataMember(IsRequired = true)]
        public SimpleSignatureOrganization Organization { get; set; }

        /// <summary>
        /// Сотрудник подписанта.
        /// </summary>
        [DataMember(IsRequired = true)]
        public SimpleSignatureEmployee Employee { get; set; }

        /// <summary>
        /// Комментарий к подписи.
        /// </summary>
        [DataMember]
        public string Comment { get; set; }
    }
}
