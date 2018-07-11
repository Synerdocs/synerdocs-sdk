using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Получатель сообщения.
    /// </summary>
    [DataContract]
    public class MessageRecipient
    {
        /// <summary>
        /// Ящик получателя.
        /// Используется при отправке.
        /// </summary>
        [DataMember]
        public string OrganizationBoxId { get; set; }

        /// <summary>
        /// ИД подразделения получателя.
        /// </summary>
        [DataMember]
        public string DepartmentId { get; set; }

        /// <summary>
        /// Наименование организации.
        /// </summary>
        [DataMember]
        public string OrganizationName { get; set; }

        /// <summary>
        /// Наименование подразделения организации.
        /// </summary>
        [DataMember]
        public string DepartmentName { get; set; }

        /// TODO: Убрать это поле.
        /// <summary>
        /// Идентификатор стороннего оператора.
        /// Заполняется сервисом.
        /// </summary>
        public string ForeignOperatorId { get; set; }

        /// <summary>
        /// Флаг, указывающий на то, что организация зарегистрирована в нашем сервисе.
        /// TODO: убрать.
        /// </summary>
        public bool IsLocal
        {
            get { return string.IsNullOrEmpty(ForeignOperatorId); }
        }

        // TODO: Equals не должен приводить к типу. Надо переделать.
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            // Если параметр нельзя привести к данному типу
            var p = obj as MessageRecipient;
            if (p == null) return false;
            return Equals(p);
        }

        /// <summary>
        /// Определяет является ли объект-параметр одинаковым с данным объектом.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        protected bool Equals(MessageRecipient p)
        {
            return string.Equals(OrganizationBoxId, p.OrganizationBoxId) && string.Equals(DepartmentId, p.DepartmentId);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((OrganizationBoxId != null ? OrganizationBoxId.GetHashCode() : 0)*397) ^
                       (DepartmentId != null ? DepartmentId.GetHashCode() : 0);
            }
        }

        public int GetHashCode(MessageRecipient obj)
        {
            unchecked
            {
                return ((obj.OrganizationBoxId != null ? obj.OrganizationBoxId.GetHashCode() : 0)*397) ^
                       (obj.DepartmentId != null ? obj.DepartmentId.GetHashCode() : 0);
            }
        }
    }
}
