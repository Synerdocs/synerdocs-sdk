using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Указания грузоотправителя.
    /// </summary>
    [DataContract]
    public class ConsignorInstructions
    {
        /// <summary>
        /// Транспортные средства.
        /// </summary>
        [DataMember]
        public List<Vehicle> Vehicles { get; set; }

        /// <summary>
        /// Указания, необходимые для выполнения требований, установленных законодательством Российской Федерации.
        /// </summary>
        [DataMember]
        public List<LegalInstruction> LegalInstructions { get; set; }

        /// <summary>
        /// Рекомендации о предельных сроках и температурном режиме перевозки.
        /// </summary>
        [DataMember]
        public CarriageInstructions CarriageInstructions { get; set; }

        /// <summary>
        /// Объявленная стоимость (ценность) груза.
        /// </summary>
        [DataMember]
        public DeclaredAmount DeclaredAmount { get; set; }

        /// <summary>
        /// Сведения о запорно-пломбировочных устройствах в случае их предоставления грузоотправителем.
        /// </summary>
        [DataMember]
        public List<string> SealingDevices { get; set; }

        /// <summary>
        /// <c>true</c>, если перегрузка запрещена; иначе - <c>false</c>.
        /// </summary>
        [DataMember]
        public bool? ReloadingProhibited { get; set; }
    }
}
