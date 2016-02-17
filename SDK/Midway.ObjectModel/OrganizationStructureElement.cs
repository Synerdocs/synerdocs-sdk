using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Класс описывающий одно подразделение
    /// организационной структуры
    /// </summary>
    [DataContract]
    public class OrganizationStructureElement
    {
        /// <summary>
        /// Идентификатор подразделения
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// Наименование подразделения
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Код подразделения
        /// </summary>
        [DataMember]
        public string Code { get; set; }

        /// <summary>
        /// КПП (для филиалов)
        /// </summary>
        [DataMember]
        public string Kpp { get; set; }

        /// <summary>
        /// Дополнительная информация, примечание
        /// </summary>
        [DataMember]
        public string AdditionalInfo { get; set; }

        /// <summary>
        /// Идентификатор родительского подразделения. 
        /// null для головного подразделения
        /// </summary>
        [DataMember]
        public string ParentId { get; set; }

        /// <summary>
        /// Идентификатор организации
        /// </summary>
        [DataMember]
        public string OrganizationId { get; set; }

        /// TODO@internal
        /// <summary>
        /// Несуществующее подразделение?
        /// </summary>
        [DataMember]
        public bool IsDeleted { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1}, Code: {2}, Kpp: {3}, ParentId: {4}, OrganizationId: {5}", Id, Name, Code, Kpp, ParentId, OrganizationId);
        }
    }



}
