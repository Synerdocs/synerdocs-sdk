using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Ответ при принятии правил использования простой ЭП.
    /// </summary>
    [DataContract]
    public class SimpleSignatureRegulationAcceptingResponse : OperationResponse
    {
        /// <summary>
        /// URL на рекомендации по организации процедуры идентификации сотрудников, использующих простую ЭП.
        /// </summary>
        [DataMember]
        public string RegulationRecommendationsUrl { get; set; }

        /// <summary>
        /// Рекомендации по организации процедуры идентификации сотрудников, использующих простую ЭП.
        /// </summary>
        [DataMember]
        public string RegulationRecommendationsMessage { get; set; }
    }
}
