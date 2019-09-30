using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Базовый класс сведений о контрагенте места погрузки/разгрузки.
    /// </summary>
    [DataContract]
    [KnownType(typeof(LegalEntityLoadingLocationCounterparty))]
    [KnownType(typeof(IndividualEntrepreneurLoadingLocationCounterparty))]
    public class LoadingLocationCounterpartyBase
    {
    }
}
