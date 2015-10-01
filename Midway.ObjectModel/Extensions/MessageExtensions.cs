using System;
using System.Collections.Generic;
using System.Linq;

namespace Midway.ObjectModel.Extensions
{
    public static class MessageExtensions
    {
        /// <summary>
        /// Формирует список получателей ответного сообщения
        /// </summary>
        /// <param name="message">оригинальное сообщение</param>
        /// <param name="sender">отправитель ответного сообщения</param>
        /// <returns></returns>
        public static MessageRecipient[] GetRecipientListForSender(this Message message, MessageRecipient sender)
        {
            var recipients = new List<MessageRecipient>();

            // добавляем отправителя оригинального сообщения
            var senderAsRecipient =
                new MessageRecipient
                    {
                        OrganizationBoxId = message.From,
                        DepartmentId = message.FromDepartment
                    };
            if (!sender.Equals(senderAsRecipient))
                recipients.Add(senderAsRecipient);

            // добавляем всех получателей, не включая указанного
            if (sender != null)
            {
                recipients.AddRange(
                    message.Recipients
                        .Where(r => !r.Equals(sender))
                        .ToList());
            }

            return recipients.ToArray();
        }

        /// <summary>
        /// Формирует список получателей ответного сообщения
        /// </summary>
        /// <param name="message">оригинальное сообщение</param>
        /// <param name="senderBox">ящик отправителя ответного сообщения</param>
        /// <returns></returns>
        public static MessageRecipient[] GetRecipientListForSender(this Message message, string senderBox = null)
        {
            var recipients = new List<MessageRecipient>();

            // добавляем отправителя оригинального сообщения
            if (!message.From.Equals(senderBox, StringComparison.InvariantCultureIgnoreCase))
                recipients.Add(new MessageRecipient
                    {
                        OrganizationBoxId = message.From,
                        DepartmentId = message.FromDepartment
                    });

            // добавляем всех получателей, не включая указанного
            recipients.AddRange(
                message.Recipients.Where(r => !r.OrganizationBoxId.Equals(senderBox, StringComparison.InvariantCultureIgnoreCase)));

            return recipients.ToArray();
        }
    }
}
