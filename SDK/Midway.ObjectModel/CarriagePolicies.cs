using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Описание условий перевозки.
    /// </summary>
    [DataContract]
    public class CarriagePolicies
    {
        /// <summary>
        /// Сроки, по истечении которых грузоотправитель и грузополучатель вправе считать груз утраченным.
        /// </summary>
        [DataMember]
        public CargoLossDeadline CargoLossDeadline { get; set; }

        /// <summary>
        /// Форма уведомления о проведении экспертизы.
        /// Для определения размера фактических недосдач, повреждения (порчи) груза.
        /// </summary>
        [DataMember]
        public string NotificationForm { get; set; }

        /// <summary>
        /// Условия хранения груза в терминале перевозчика.
        /// </summary>
        [DataMember]
        public CarrierStoragePolicies CarrierStoragePolicies { get; set; }

        /// <summary>
        /// Условия осуществления погрузочных работ.
        /// </summary>
        [DataMember]
        public CargoHandlingPolicies CargoLoadingPolicies { get; set; }

        /// <summary>
        /// Условия осуществления разгрузочных работ.
        /// </summary>
        [DataMember]
        public CargoHandlingPolicies CargoUnloadingPolicies { get; set; }

        /// <summary>
        /// Порядок внесения записей в транспортную накладную.
        /// </summary>
        [DataMember]
        public List<RecordIntroductionPolicy> RecordIntroductionPolicies { get; set; }

        /// <summary>
        /// Штрафы, предусмотренные в рамках перевозки.
        /// </summary>
        [DataMember]
        public List<PenaltyCharge> Penalties { get; set; }

        /// <summary>
        /// Иные сведения о перевозке.
        /// </summary>
        [DataMember]
        public InfoFieldFull AdditionalInfo { get; set; }
    }
}
