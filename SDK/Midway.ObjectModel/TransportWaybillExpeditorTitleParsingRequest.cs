using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на парсинг модели титула экспедитора транспортной накладной.
    /// </summary>
    [DataContract]
    public class TransportWaybillExpeditorTitleParsingRequest : ParsingRequest
    {
    }
}
