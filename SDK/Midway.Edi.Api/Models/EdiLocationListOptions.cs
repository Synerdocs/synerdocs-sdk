using System.Runtime.Serialization;
using Midway.Edi.Api.Annotations;

namespace Midway.Edi.Api.Models
{
    /// <summary>
    /// Параметры получения списка точек доставки/отправки
    /// </summary>
    [DataContract]
    public class EdiLocationListOptions
    {
        /// <summary>
        /// Ящик организации
        /// </summary>
        [DataMember]
        [ReferenceValidation(ValidationAttributeType.Required,
            nameof(LocationGln), "", null,
            ErrorMessage = "Укажите ящик организации, если GLN точки доставки не указан")]
        public string OrganizationBox { get; set; }

        /// <summary>
        /// GLN точки доставки
        /// </summary>
        [DataMember]
        [ReferenceValidation(ValidationAttributeType.Required,
            nameof(OrganizationBox), "", null,
            ErrorMessage = "GLN точки доставки, если ящик организации не указан")]
        public string LocationGln { get; set; }

        /// <summary>
        /// Номер первой записи
        /// </summary>
        [DataMember]
        public int First { get; set; }

        /// <summary>
        /// Максимальное количество записей
        /// </summary>
        [DataMember]
        public int Max { get; set; }
    }
}
