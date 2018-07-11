using System;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Изменение условий перевозки.
    /// </summary>
    [DataContract]
    public class CarriagePoliciesChange
    {
        /// <summary>
        /// Дата и время изменения условий перевозки.
        /// </summary>
        [DataMember]
        public DateTime? ChangedAt { get; set; }

        /// <summary>
        /// Когда произошло изменение условий перевозки.
        /// При движении, при выгрузке или при других обстоятельствах.
        /// </summary>
        [DataMember]
        public NameCodeObject ChangedWhen { get; set; }

        /// <summary>
        /// Описание изменений условий перевозки.
        /// </summary>
        [DataMember]
        public string Description { get; set; }
    }
}
