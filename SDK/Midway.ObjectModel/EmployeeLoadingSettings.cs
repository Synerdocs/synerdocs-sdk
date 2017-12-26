using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Настройки загрузки сотрудника.
    /// </summary>
    [DataContract]
    public class EmployeeLoadingSettings
    {
        /// <summary>
        /// Если <c>true</c>, то загружается пользователь; иначе - не загружается.
        /// </summary>
        [DataMember] 
        public bool WithUser { get; set; }

        /// <summary>
        /// Если <c>true</c>, то загружается организация; иначе - не загружается.
        /// </summary>
        [DataMember]
        public bool WithOrganization { get; set; }

        /// <summary>
        /// Если <c>true</c>, то загружается сертификат; иначе - не загружается.
        /// </summary>
        [DataMember]
        public bool WithCertificate { get; set; }

        /// <summary>
        /// Если <c>true</c>, то загружаются настройки сотрудника; иначе - не загружаются.
        /// </summary>
        [DataMember]
        public bool WithSettings { get; set; }
    }
}
