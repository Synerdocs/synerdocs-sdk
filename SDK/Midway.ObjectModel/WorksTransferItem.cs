using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    [DataContract]
    public class WorksTransferItem : ProductBase
    {
        /// <summary>
        /// Описание
        /// </summary>
        [DataMember]
        public string Description { get; set; }
    }
}
