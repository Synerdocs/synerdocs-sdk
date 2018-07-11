using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Получатель сообщения со статусом документооборота.
    /// </summary>
    [DataContract]
    public class MessageRecipientWithStatus : MessageRecipient
    {
        public MessageRecipientWithStatus(MessageRecipient recipient)
        {
            OrganizationBoxId = recipient.OrganizationBoxId;
            DepartmentId = recipient.DepartmentId;
        }

        public MessageRecipientWithStatus()
        {
            
        }
        
        /// <summary>
        /// Статус документооборота c этим получателем.
        /// </summary>
        [DataMember]
        public DocumentFlowStatus Status { get; set; }
    }
}
