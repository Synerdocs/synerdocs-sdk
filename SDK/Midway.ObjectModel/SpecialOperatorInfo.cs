using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Сведения об операторе электронного документооборота отправителя.
    /// </summary>
    [DataContract]
    public class SpecialOperatorInfo
    {
        /// <summary>
        /// Идентификатор оператора электронного документооборота отправителя информации.
        /// </summary>
        [DataMember]
        public string OperatorCode { get; set; }

        /// <summary>
        /// Инн оператора электронного документооборота отправителя информации.
        /// </summary>
        [DataMember]
        public string Inn { get; set; }

        /// <summary>
        /// Наименование организации оператора электронного документооборота отправителя информации.
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}
