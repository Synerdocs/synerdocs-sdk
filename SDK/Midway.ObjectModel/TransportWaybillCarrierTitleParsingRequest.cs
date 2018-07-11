using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на парсинг модели титула перевозчика транспортной накладной.
    /// </summary>
    [DataContract]
    public class TransportWaybillCarrierTitleParsingRequest : ParsingRequest
    {
    }
}