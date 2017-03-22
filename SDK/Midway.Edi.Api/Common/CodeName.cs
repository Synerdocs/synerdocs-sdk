using System.Runtime.Serialization;

namespace Midway.Edi.Api.Common
{
    /// <summary>
    /// Пара Код-Наименование
    /// </summary>
    [DataContract]
    public class CodeName
    {
        /// <summary>
        /// Код
        /// </summary>
        [DataMember]
        public string Code { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}
