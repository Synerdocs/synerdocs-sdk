using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Документ, удостоверяющий личность.
    /// </summary>
    [DataContract]
    public class CertificateIdentityDocument
    {
        /// <summary>
        /// Тип документа удостоверяющего личность.
        /// </summary>
        [DataMember(IsRequired = true)]
        public EnumValue IdentityDocumentType { get; set; }

        /// <summary>
        /// Серия документа, удостоверяющего личность.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Series { get; set; }

        /// <summary>
        /// Номер документа, удостоверяющего личность.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Number { get; set; }

        /// <summary>
        /// Дата выдачи документа, удостоверяющего личность.
        /// </summary>
        [DataMember(IsRequired = true)]
        public DateTime IssueDate { get; set; }

        /// <summary>
        /// Выдан кем (комментарий).
        /// Указывается наименование органа, выдавшего документ, или иная текстовая информация (комментарий).
        /// </summary>
        [DataMember]
        public string IssuedBy { get; set; }

        /// <summary>
        /// Код подразделения, выдавшего документ.
        /// </summary>
        [DataMember]
        public string IssuerDepartmentCode { get; set; }
    }
}
