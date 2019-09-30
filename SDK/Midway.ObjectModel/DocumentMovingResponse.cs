using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Результат выполнения операции перемещения документа
    /// из одного подразделения в другое.
    /// </summary>
    [DataContract]
    public class DocumentMovingResponse : OperationResponse
    {
        /// <summary>
        /// Признак того, что в результате выполнения операции
        /// документ был перемещен.
        /// </summary>
        [DataMember]
        public bool Moved { get; set; }
    }
}
