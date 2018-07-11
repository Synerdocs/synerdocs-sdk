using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Запрос на парсинг модели титула грузополучателя транспортной накладной.
    /// </summary>
    [DataContract]
    public class TransportWaybillConsigneeTitleParsingRequest : ParsingRequest
    {
    }
}