using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Общая стоимость, сумма налога, стоимость с налогом о передаче работ / услуг
    /// </summary>
    [DataContract]
    public class WorksTransferTotal : AmountTotal
    {
    }
}
