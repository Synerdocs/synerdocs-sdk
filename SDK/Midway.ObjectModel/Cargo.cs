using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Груз.
    /// </summary>
    [DataContract]
    public class Cargo
    {
        /// <summary>
        /// Отгрузочное наименование груза.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Состояние груза.
        /// </summary>
        [DataMember]
        public string State { get; set; }

        /// <summary>
        /// Опломбирование груза.
        /// </summary>
        [DataMember]
        public string Seal { get; set; }

        /// <summary>
        /// Другая необходимая информация о грузе.
        /// </summary>
        [DataMember]
        public InfoFieldFull AdditionalInfo { get; set; }
    }
}
