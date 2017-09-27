using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Тип провайдера облачной ЭП.
    /// </summary>
    [DataContract]
    public enum CloudProviderType
    {
        /// <summary>
        /// Калуга Астрал.
        /// </summary>
        [EnumMember]
        [Description("ЗАО 'Калуга Астрал'")]
        KalugaAstral = 1
    }
}
