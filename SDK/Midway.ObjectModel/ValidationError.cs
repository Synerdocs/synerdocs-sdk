using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информация о логической ошибке, выявленной валидацией
    /// </summary>
    [DataContract]
    public class ValidationError
    {
        /// <summary>
        /// Тип ошибки
        /// </summary>
        [DataMember]
        public EnumValue ErrorType { get; set; }

        /// <summary>
        /// Поле
        /// </summary>
        [DataMember]
        public string Field { get; set; }

        /// <summary>
        /// Описание ошибки
        /// </summary>
        [DataMember]
        public string Description { get; set; }
    }
}
