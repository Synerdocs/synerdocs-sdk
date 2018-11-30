using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на парсинг модели титула изменения места доставки транспортной накладной.
    /// </summary>
    [DataContract]
    public class TransportWaybillDeliveryPlaceChangeTitleParsingRequest : ParsingRequest
    {
    }
}