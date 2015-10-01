using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    [DataContract]
    public class FormatControlResult
    {
        /// <summary>
        /// Имя поля
        /// </summary>
        [DataMember]
        public string Field { get; set; }

        /// <summary>
        /// Статус проверки
        /// </summary>
        [DataMember]
        public List<FormatControlError> Statuses { get; set; }

        /// <summary>
        /// Дополнительная информация по результату проверки
        /// </summary>
        [DataMember]
        public string Message { get; set; }
    }
}
