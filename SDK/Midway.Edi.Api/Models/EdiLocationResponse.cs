using System.Runtime.Serialization;

namespace Midway.Edi.Api.Models
{
    /// <summary>
    /// Результат выполнения операции над точкой доставки/отправки
    /// </summary>
    [DataContract]
    public class EdiLocationResponse
    {
        /// <summary>
        /// Точка доставки/отправки после выполнения операции
        /// </summary>
        [DataMember]
        public EdiLocation Location { get; set; }

        /// <summary>
        /// Результат операции
        /// </summary>
        [DataMember]
        public ResponseResult Result { get; set; }
    }
}
