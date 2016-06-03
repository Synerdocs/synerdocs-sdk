using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Значение перечисления обеспечивающее обратную совместимость WCF-сервисов
    /// при добавлении нового значения в отличие от обычных перечислений
    /// </summary>
    [DataContract]
    public class EnumValue
    {
        /// <summary>
        /// Числовой код значения
        /// </summary>
        [DataMember]
        public int Code { get; set; }

        /// <summary>
        /// Строковое имя значения
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Строковое описание значения
        /// </summary>
        [DataMember]
        public string Description { get; set; }
    }
}
