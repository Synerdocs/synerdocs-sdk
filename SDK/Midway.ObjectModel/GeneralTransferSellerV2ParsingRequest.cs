using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на парсинг модели титула продавца УПД.
    /// Формат УПД, утвержденный ММВ-7-15/820.
    /// </summary>
    [DataContract]
    public class GeneralTransferSellerV2ParsingRequest : ParsingRequest
    {
    }
}
