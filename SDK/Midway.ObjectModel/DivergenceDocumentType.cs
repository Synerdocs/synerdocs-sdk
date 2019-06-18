using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Вид документа о расхождениях.
    /// </summary>
    [DataContract]
    public enum DivergenceDocumentType
    {
        /// <summary>
        /// Документ о приемке с расхождениями.
        /// </summary>
        [EnumMember]
        [Description("Документ о приемке с расхождениями")]
        DocumentOfAcceptanceWithDivergence = 1,

        /// <summary>
        /// Документ о расхождениях.
        /// </summary>
        [EnumMember]
        [Description("Документ о расхождениях")]
        DivergenceDocument = 2
    }
}
