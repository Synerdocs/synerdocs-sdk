using System;
using System.Collections.Generic;
using System.Linq;

namespace Midway.ObjectModel.Extensions
{
    public static class MessageExtensions
    {
        /// <summary>
        /// Формирует список получателей ответного сообщения.
        /// </summary>
        /// <param name="message">Оригинальное сообщение.</param>
        /// <param name="sender">Отправитель ответного сообщения.</param>
        /// <returns>Получатели сообщения.</returns>
        public static MessageRecipient[] GetRecipientListForSender(this Message message, MessageRecipient sender)
        {
            var isOriginalSenderEqualsCurrent = message.From.Equals(sender.OrganizationBoxId, StringComparison.InvariantCultureIgnoreCase);

            // Добавляем отправителя оригинального сообщения.
            var recipients = new List<MessageRecipient>();
            if (!isOriginalSenderEqualsCurrent)
                recipients.Add(new MessageRecipient
                {
                    OrganizationBoxId = message.From,
                    DepartmentId = message.FromDepartment
                });

            // Добавляем всех получателей, не включая указанного.
            if (sender != null)
            {
                recipients.AddRange(isOriginalSenderEqualsCurrent
                    ? message.Recipients
                    : message.Recipients.Where(r => !r.Equals(sender)));
            }

            return recipients.ToArray();
        }

        /// <summary>
        /// Формирует список получателей ответного сообщения.
        /// </summary>
        /// <param name="message">Оригинальное сообщение.</param>
        /// <param name="senderBox">Ящик отправителя ответного сообщения.</param>
        /// <returns>Получатели сообщения.</returns>
        public static MessageRecipient[] GetRecipientListForSender(this Message message, string senderBox = null)
        {
            var isOriginalSenderEqualsCurrent = message.From.Equals(senderBox, StringComparison.InvariantCultureIgnoreCase);

            // Добавляем отправителя оригинального сообщения.
            var recipients = new List<MessageRecipient>();
            if (!isOriginalSenderEqualsCurrent)
                recipients.Add(new MessageRecipient
                {
                    OrganizationBoxId = message.From,
                    DepartmentId = message.FromDepartment
                });

            // Добавили всех получателей и выбрали среди них различных.
            recipients.AddRange(isOriginalSenderEqualsCurrent
                    ? message.Recipients
                    : message.Recipients.Where(r => !r.OrganizationBoxId.Equals(senderBox, StringComparison.InvariantCultureIgnoreCase)));

            return recipients.Distinct().ToArray();
        }
    }
}
