using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на парсинг модели титула грузоотправителя транспортной накладной.
    /// </summary>
    [DataContract]
    public class TransportWaybillConsignorTitleParsingRequest : ParsingRequest
    {
    }
}
