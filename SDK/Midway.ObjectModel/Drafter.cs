using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Составитель документа
    /// </summary>
    [DataContract]
    public class Drafter
    {
        /// <summary>
        /// Наименование экономического субъекта – составителя информации
        /// </summary>
        [DataMember]
        public string OrganizationName { get; set; }

        /// <summary>
        /// Основание, по которому экономический субъект является составителем информации
        /// </summary>
        [DataMember]
        public string AuthorityBase { get; set; }
    }
}
