using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Настройки передачи черновика сообщения по ИД сотрудника.
    /// </summary>
    public class DraftMessageEmployeeMovingSettings : DraftMessageMovingSettings
    {
        /// <summary>
        /// Внешний ИД сотрудника, которому будет передан черновик.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string EmployeeId { get; set; }
    }
}
