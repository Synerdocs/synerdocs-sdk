using System.Runtime.Serialization;

namespace Midway.ObjectModel.GeneralTransferCorrectionV3
{
    /// <summary>
    /// Запрос на парсинг модели титула покупателя УКД версии 3.
    /// Формат УКД, утвержденный приказом № ЕД-7-26/736.
    /// </summary>
    [DataContract]
    public class GeneralTransferCorrectionBuyerTitleV3ParsingRequest : ParsingRequest
    {
    }
}
