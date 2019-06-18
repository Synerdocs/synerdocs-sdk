using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация о типе документа.
    /// </summary>
    [DataContract]
    public class DocumentTypeInfo
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public DocumentTypeInfo()
        {
            Purposes = new List<EnumValue>();
        }

        /// <summary>
        /// Тип документа.
        /// Соответствует перечислению <see cref="ObjectModel.DocumentType"/>.
        /// </summary>
        [DataMember]
        public EnumValue DocumentType { get; set; }

        /// <summary>
        /// Вид неформализованного документа.
        /// </summary>
        [DataMember]
        public string UntypedKind { get; set; }

        /// <summary>
        /// Номер версии типа документа.
        /// </summary>
        [DataMember]
        public int? VersionNumber { get; set; }

        /// <summary>
        /// Назначение документа.
        /// Соответствует перечислению <see cref="DocumentPurpose"/>.
        /// </summary>
        [DataMember]
        public List<EnumValue> Purposes { get; set; }
    }
}
