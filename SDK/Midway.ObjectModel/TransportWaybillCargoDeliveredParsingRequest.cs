using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на парсинг модели титула водителя (сдача груза) транспортной накладной.
    /// </summary>
    [DataContract]
    public class TransportWaybillCargoDeliveredParsingRequest : ParsingRequest
    {
    }
}
