using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Базовый класс настроек передачи черновика сообщения.
    /// </summary>
    [DataContract]
    [KnownType(typeof(DraftMessageUserMovingSettings))]
    [KnownType(typeof(DraftMessageEmployeeMovingSettings))]
    public class DraftMessageMovingSettings
    {   
        /// <summary>
        /// Внешний ИД черновика сообщения.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string DraftMessageId { get; set; }
    }
}