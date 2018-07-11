using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Объявленная стоимость (ценность).
    /// </summary>
    [DataContract]
    public class DeclaredAmount
    {
        /// <summary>
        /// Объявленная стоимость.
        /// </summary>
        [DataMember]
        public Amount Total { get; set; }

        /// <summary>
        /// Объявленная ценность.
        /// </summary>
        [DataMember]
        public Amount Worth { get; set; }

        /// <summary>
        /// Иные сведения об объявленной стоимости (ценности).
        /// </summary>
        [DataMember]
        public InfoFieldFull AdditionalInfo { get; set; }
    }
}
