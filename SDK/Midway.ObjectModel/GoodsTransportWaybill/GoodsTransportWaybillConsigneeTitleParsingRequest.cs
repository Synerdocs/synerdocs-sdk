using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Запрос на парсинг модели титула грузополучателя транспортной накладной.
    /// </summary>
    [DataContract]
    public class GoodsTransportWaybillConsigneeTitleParsingRequest : ParsingRequest
    {
    }
}