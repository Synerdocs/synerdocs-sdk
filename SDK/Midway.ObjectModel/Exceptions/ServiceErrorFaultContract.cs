using System.Runtime.Serialization;

namespace Midway.ObjectModel.Exceptions
{
    /// <summary>
    /// Сообщение об ошибке сервиса
    /// </summary>
    [DataContract]
    public class ServiceErrorFaultContract
    {
        /// <summary>
        /// Код сообщения об ошибке
        /// </summary>
        [DataMember]
        public string Code { get; set; }

        /// <summary>
        /// Наименование поля, при валидации которого произошла ошибка
        /// </summary>
        [DataMember]
        public string Field { get; set; }

        /// <summary>
        /// Сообщение об ошибке сервиса
        /// </summary>
        [DataMember]
        public string Message { get; set; }

        /// <summary>
        /// Стек-трейс
        /// </summary>
        [DataMember]
        public string StackTrace { get; set; }
    }
}