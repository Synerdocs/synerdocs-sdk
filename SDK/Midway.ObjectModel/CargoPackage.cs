using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Упаковка груза.
    /// </summary>
    [DataContract]
    public class CargoPackage
    {
        /// <summary>
        /// Способы упаковки груза.
        /// </summary>
        [DataMember]
        public List<NameCodeObject> PackingMethods { get; set; }

        /// <summary>
        /// Вид дополнительной упаковки груза.
        /// </summary>
        [DataMember]
        public NameCodeObject AdditionalPackage { get; set; }
    }
}
