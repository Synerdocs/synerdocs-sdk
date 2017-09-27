using System;
using System.Collections.Generic;
using System.Linq;
using Midway.ObjectModel;
using Midway.ObjectModel.Extensions;

namespace Midway.ServiceClient
{
    /// <summary>
    /// Фабрика сообщений со служебными документами.
    /// </summary>
    public class MessageFactory
    {
        private readonly Client _client;
        private readonly string _currentBox;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="client">Клиент API.</param>
        /// <param name="currentBox">Текущий ящик.</param>
        public MessageFactory(Client client, string currentBox)
        {
            _client = client;
            _currentBox = currentBox;
        }

        /// <summary>
        /// Добавить в сообщение документ с подписью перед отправкой.
        /// </summary>
        /// <param name="message">Сообщение.</param>
        /// <param name="document">Документ.</param>
        /// <param name="signature">Подпись.</param>
        /// <returns>Сообщение.</returns>
        public static Message AddDocumentWithSignature(Message message, Document document, ISignature signature)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));
            if (document == null)
                throw new ArgumentNullException(nameof(document));
            if (signature == null)
                throw new ArgumentNullException(nameof(signature));
            if (string.IsNullOrEmpty(document.Id))
                throw new ArgumentException("Не указан идентификатор документа");

            if (message.Documents == null)
                message.Documents = new Document[0];
            if (message.Signs == null)
                message.Signs = new Sign[0];
            if (message.SimpleSignatures == null)
                message.SimpleSignatures = new SimpleSignature[0];

            if (message.Documents.Any(d => d.Id == document.Id))
                throw new ArgumentException("Документ с идентификатором \"{0}\" уже добавлен в сообщение", document.Id);

            AddDocument(message, document);
            AddSignature(message, document, signature);

            return message;
        }

        /// <summary>
        /// Создать сообщение с СД ИОП (регламент ЭСФ).
        /// </summary>
        /// <param name="message">Сообщение.</param>
        /// <param name="document">Документ.</param>
        /// <param name="signatureFactory">Фабрика подписи.</param>
        /// <returns>Сообщение.</returns>
        public Message CreateInvoiceReceipt(
            Message message,
            Document document,
            Func<Document, ISignature> signatureFactory)
        {
            var generatedNotice = _client.GenerateInvoiceReceipt(_currentBox, document.Id);
            return CreateServiceDocumentMessage(message, document,
                DocumentType.ServiceInvoiceReceipt,
                generatedNotice, signatureFactory);
        }

        /// <summary>
        /// Создать сообщение с СД УОУ (регламент ЭСФ).
        /// </summary>
        /// <param name="message">Сообщение.</param>
        /// <param name="document">Документ.</param>
        /// <param name="text">Комментарий УОУ.</param>
        /// <param name="signatureFactory">Фабрика подписи.</param>
        /// <returns>Сообщение.</returns>
        public Message CreateInvoiceAmendmentRequest(
            Message message,
            Document document,
            string text,
            Func<Document, ISignature> signatureFactory)
        {
            var amendmentRequest = _client.GenerateInvoiceAmendmentRequest(_currentBox, document.Id, text);
            return CreateServiceDocumentMessage(message, document,
                DocumentType.ServiceInvoiceAmendmentRequest,
                amendmentRequest, signatureFactory);
        }

        /// <summary>
        /// Создать сообщение с СД ИОП (общий регламент).
        /// </summary>
        /// <param name="message">Сообщение.</param>
        /// <param name="document">Документ.</param>
        /// <param name="signatureFactory">Фабрика подписи.</param>
        /// <returns>Сообщение.</returns>
        public Message CreateReceipt(
            Message message,
            Document document,
            Func<Document, ISignature> signatureFactory)
        {
            var deliveryConfirmation = _client.GenerateDeliveryConfirmation(_currentBox, document.Id);
            return CreateServiceDocumentMessage(message, document,
                DocumentType.ServiceReceipt,
                deliveryConfirmation, signatureFactory);
        }

        /// <summary>
        /// Создать сообщение с СД УОУ (общий регламент).
        /// </summary>
        /// <param name="message">Сообщение.</param>
        /// <param name="document">Документ.</param>
        /// <param name="text">Комментарий УОУ.</param>
        /// <param name="signatureFactory">Фабрика подписи.</param>
        /// <returns>Сообщение.</returns>
        public Message CreateAmendmentRequest(
            Message message,
            Document document,
            string text,
            Func<Document, ISignature> signatureFactory)
        {
            var amendmentRequest = _client.GenerateAmendmentRequest(_currentBox, document.Id, text);
            return CreateServiceDocumentMessage(message, document,
                DocumentType.ServiceAmendmentRequest,
                amendmentRequest, signatureFactory);
        }

        /// <summary>
        /// Создать сообщение с подписью (общий регламент)
        /// </summary>
        /// <param name="message">Сообщение.</param>
        /// <param name="document">Документ.</param>
        /// <param name="signatureFactory">Фабрика подписи.</param>
        /// <returns>Сообщение.</returns>
        public Message CreateSignature(
            Message message,
            Document document,
            Func<Document, ISignature> signatureFactory)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));
            if (document == null)
                throw new ArgumentNullException(nameof(document));
            if (document.Content == null)
                throw new ArgumentException("Содержимое документа не загружено");
            if (signatureFactory == null)
                throw new ArgumentNullException(nameof(signatureFactory));

            var signatureMessage = new Message
            {
                Id = Guid.NewGuid().ToString(),
                From = _currentBox,
                Recipients = message.GetRecipientListForSender(_currentBox),
            };

            AddSignature(
                signatureMessage, document,
                signatureFactory(document));

            return signatureMessage;
        }

        /// <summary>
        /// Создать сообщение со служебным документом.
        /// </summary>
        /// <param name="message">Сообщение.</param>
        /// <param name="parentDocument">Родительский документ.</param>
        /// <param name="serviceDocumentType">Тип служебного документа.</param>
        /// <param name="generatedNotice">Содержимое служебного документа.</param>
        /// <param name="signatureFactory">Фабрика подписи.</param>
        /// <returns>Сообщение.</returns>
        private Message CreateServiceDocumentMessage(
            Message message,
            Document parentDocument,
            DocumentType serviceDocumentType,
            NamedContent generatedNotice,
            Func<Document, ISignature> signatureFactory)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));
            if (parentDocument == null)
                throw new ArgumentNullException(nameof(parentDocument));
            if (generatedNotice == null)
                throw new ArgumentNullException(nameof(generatedNotice));
            if (signatureFactory == null)
                throw new ArgumentNullException(nameof(signatureFactory));

            var document = new Document
            {
                Id = Guid.NewGuid().ToString(),
                DocumentType = serviceDocumentType,
                ParentDocumentId = parentDocument.Id,
                FileName = generatedNotice.Name,
                Content = generatedNotice.Content
            };

            return AddDocumentWithSignature(
                new Message
                {
                    Id = Guid.NewGuid().ToString(),
                    From = _currentBox,
                    Recipients = message.GetRecipientListForSender(_currentBox),
                },
                document,
                signatureFactory(document));
        }

        /// <summary>
        /// Добавить документ в сообщение.
        /// </summary>>
        /// <param name="message">Сообщение.</param>
        /// <param name="document">Документ.</param>
        private static void AddDocument(Message message, Document document)
        {
            var documents = new List<Document>(message.Documents);
            documents.Add(document);
            message.Documents = documents.ToArray();
        }

        /// <summary>
        /// Добавить подпись в сообщение.
        /// </summary>
        /// <param name="message">Сообщение.</param>
        /// <param name="document">Документ.</param>
        /// <param name="signature">Подпись.</param>
        private static void AddSignature(Message message, Document document, ISignature signature)
        {
            signature.DocumentId = document.Id;
            signature.Id = Guid.NewGuid().ToString();

            if (signature is Sign)
            {
                var signs = new List<Sign>(message.Signs);
                signs.Add(signature as Sign);
                message.Signs = signs.ToArray();
            }
            else
            {
                var signs = new List<SimpleSignature>(message.SimpleSignatures);
                signs.Add(signature as SimpleSignature);
                message.SimpleSignatures = signs.ToArray();
            }
        }
    }
}