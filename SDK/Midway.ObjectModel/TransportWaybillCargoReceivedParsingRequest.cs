using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на парсинг модели титула водителя (прием груза) транспортной накладной.
    /// </summary>
    [DataContract]
    public class TransportWaybillCargoReceivedParsingRequest : ParsingRequest
    {
    }
}
