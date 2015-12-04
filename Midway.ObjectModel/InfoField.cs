using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Информационное поле
    /// </summary>
    [DataContract]
    public class InfoField
    {
        /// <summary>
        /// Идентификатор файла информационного поля
        /// </summary>
        [DataMember]
        public string FileId { get; set; }

        /// <summary>
        /// Текстовая информация
        /// </summary>
        [DataMember]
        public string Text { get; set; }
    }
}
