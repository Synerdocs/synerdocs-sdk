using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Midway.Crypto;
using Midway.ObjectModel;
using Midway.ObjectModel.Extensions;

namespace Midway.ServiceClient
{
    /// <summary>
    /// Генерация сообщений со служебными документами
    /// </summary>
    public class MessageFactory
    {
        private readonly Client client;
        private readonly string CurrentBox;

        public MessageFactory(Client client, string currentBox)
        {
            this.client = client;
            this.CurrentBox = currentBox;
        }

        /// <summary>
        /// Добавить в сообщение документ перед отправкой
        /// </summary>
        /// <param name="message">сообщение</param>
        /// <param name="document"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        public static Message AddDocumentToNewMessage(Message message, Document document, byte[] sign)
        {
            if (message == null) throw new ArgumentNullException("message");
            if (document == null) throw new ArgumentNullException("document");
            if (sign == null) throw new ArgumentNullException("sign");
            if (string.IsNullOrEmpty(document.Id))
            {
                throw new ArgumentException("Не указан идентификатор документа");
            }

            if (message.Documents == null)
                message.Documents = new Document[0];
            if (message.Signs == null)
                message.Signs = new Sign[0];

            if (message.Documents.Any(d => d.Id == document.Id))
                throw new ArgumentException("Документ с идентификатором \"{0}\" уже добавлен в сообщение", document.Id);

            var documents = new List<Document>(message.Documents);
            documents.Add(document);
            message.Documents = documents.ToArray();

            var signs = new List<Sign>(message.Signs);
            signs.Add(new Sign()
            {
                Id = Guid.NewGuid().ToString(),
                DocumentId = document.Id,
                Raw = sign
            });
            message.Signs = signs.ToArray();

            return message;
        }

        /// <summary>
        /// Создать сообщение с СД ИОП (регламент ЭСФ)
        /// </summary>
        /// <returns></returns>
        public Message CreateInvoiceReceipt(Message message, Document document, X509Certificate2 certificate2)
        {
            if (message == null) throw new ArgumentNullException("message");
            if (document == null) throw new ArgumentNullException("document");
            if (certificate2 == null) throw new ArgumentNullException("certificate2");
            var generatedNotice = client.GenerateInvoiceReceipt(CurrentBox, document.Id);
            return CreateServiceDocumentMessage(message, document, certificate2, DocumentType.ServiceInvoiceReceipt, generatedNotice);
        }

        public Message CreateServiceDocumentMessage(Message message, Document document, X509Certificate2 certificate2,
                                                            DocumentType documentType, NamedContent generatedNotice)
        {
            var noticeMessage = AddDocumentToNewMessage(
                new Message()
                    {
                        Id = Guid.NewGuid().ToString(),
                        From = CurrentBox,
                        Recipients = message.GetRecipientListForSender(CurrentBox),
                    },
                new Document()
                    {
                        Id = (Guid.NewGuid().ToString()),
                        DocumentType =
                            documentType,
                        ParentDocumentId = document.Id,
                        FileName = generatedNotice.Name,
                        Content = generatedNotice.Content
                    },
                CryptoApiHelper.Sign(certificate2,
                                     generatedNotice.Content, true));
            return noticeMessage;
        }

        /// <summary>
        /// Создать сообщение с СД УОУ (регламент ЭСФ)
        /// </summary>
        /// <param name="message"></param>
        /// <param name="document"></param>
        /// <param name="certificate"></param>
        /// <returns></returns>
        public Message GenerateInvoiceAmendmentRequest(Message message, Document document, string text, X509Certificate2 certificate)
        {
            if (message == null) throw new ArgumentNullException("message");
            if (document == null) throw new ArgumentNullException("document");
            if (certificate == null) throw new ArgumentNullException("certificate");
            var amendmentRequest = client.GenerateInvoiceAmendmentRequest(CurrentBox, document.Id, text);
            return CreateServiceDocumentMessage(message, document, certificate, DocumentType.ServiceInvoiceAmendmentRequest, amendmentRequest);
        }

        /// <summary>
        /// Создать сообщение с СД ИОП (общий регламент)
        /// </summary>
        /// <param name="message"></param>
        /// <param name="document"></param>
        /// <param name="certificate2"></param>
        /// <returns></returns>
        public Message CreateReceipt(Message message, Document document, X509Certificate2 certificate2)
        {
            if (message == null) throw new ArgumentNullException("message");
            if (document == null) throw new ArgumentNullException("document");
            if (certificate2 == null) throw new ArgumentNullException("certificate2");
            var deliveryConfirmation = client.GenerateDeliveryConfirmation(CurrentBox, document.Id);

            return CreateServiceDocumentMessage(message, document, certificate2, DocumentType.ServiceReceipt, deliveryConfirmation);
        }

        /// <summary>
        /// Создать сообщение с подписью (общий регламент)
        /// </summary>
        /// <param name="message"></param>
        /// <param name="document"></param>
        /// <param name="certificate"></param>
        /// <returns></returns>
        public Message CreateSign(Message message, Document document, X509Certificate2 certificate)
        {
            if (message == null) throw new ArgumentNullException("message");
            if (document == null) throw new ArgumentNullException("document");
            if (certificate == null) throw new ArgumentNullException("certificate");
            if (document.Content == null)
                throw new ArgumentException("Содержимое документа не загружено");
            var sign = CryptoApiHelper.Sign(certificate, document.Content, true);
            var signMessage = new Message()
            {
                Id = Guid.NewGuid().ToString(),
                From = CurrentBox,
                Recipients = message.GetRecipientListForSender(CurrentBox),
                Signs = new []
                    {
                        new Sign()
                        {
                            DocumentId = document.Id,
                            Raw = sign,
                            Id = Guid.NewGuid().ToString()
                        }
                    }
            };
            return signMessage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="document"></param>
        /// <param name="certificate"></param>
        /// <returns></returns>
        public Message CreateAmendmentRequest(Message message, Document document, string text, X509Certificate2 certificate)
        {
            var amendmentRequest = client.GenerateAmendmentRequest(CurrentBox, document.Id, text);
            return CreateServiceDocumentMessage(message, document, certificate, DocumentType.ServiceAmendmentRequest, amendmentRequest);
        }
    }
}