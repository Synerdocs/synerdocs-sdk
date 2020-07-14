using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на парсинг модели титула изменения водителя и/или ТС транспортной накладной.
    /// </summary>
    [DataContract]
    public class TransportWaybillDriverOrVehicleChangeTitleParsingRequest : ParsingRequest
    {
    }
}
