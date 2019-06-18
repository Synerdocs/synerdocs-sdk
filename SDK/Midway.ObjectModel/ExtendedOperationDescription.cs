using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Расширенная информация о содержании операции.
    /// </summary>
    [DataContract]
    public class ExtendedOperationDescription
    {
        /// <summary>
        /// Итоговый результат приемки товара, соответствует перечислению 
        /// <see cref="Midway.ObjectModel.GoodsAcceptanceResultType"/>.
        /// </summary>
        [DataMember(IsRequired = true)]
        public EnumValue GoodsAcceptanceResultType { get; set; }

        /// <summary>
        /// Вид документа о расхождениях, соответствует перечислению 
        /// <see cref="Midway.ObjectModel.DivergenceDocumentType"/>.
        /// </summary>
        [DataMember]
        public EnumValue DivergenceDocumentType { get; set; }

        /// <summary>
        /// Наименование, номер и дата документа о расхождениях.
        /// </summary>
        [DataMember]
        public NamedNumberDate DivergenceDocument { get; set; }

        /// <summary>
        /// ИД файла обмена документа о расхождениях, сформированного покупателем.
        /// </summary>
        [DataMember]
        public string FileId { get; set; }
    }
}
