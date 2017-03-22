using System.Runtime.Serialization;

namespace Midway.Edi.Api.Models
{
    /// <summary>
    /// Результат получения списка точек доставки/отправки
    /// </summary>
    [DataContract]
    public class EdiLocationListResponse
    {
        /// <summary>
        /// Общее количество точек доставки/отправки
        /// </summary>
        [DataMember]
        public int Total { get; set; }

        /// <summary>
        /// Полученные точки доставки/отправки
        /// </summary>
        [DataMember]
        public EdiLocation[] Items { get; set; }

        /// <summary>
        /// Результат операции
        /// </summary>
        [DataMember]
        public ResponseResult Result { get; set; }
    }
}
