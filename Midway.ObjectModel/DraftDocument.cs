using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Документ черновика сообщения
    /// </summary>
    [DataContract]
    public class DraftDocument
    {
        /// <summary>
        /// Идентификатор черновика документа
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// Тип документа
        /// </summary>
        [DataMember]
        public DocumentType DocumentType { get; set; }

        /// <summary>
        /// Имя документа
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Имя файла
        /// </summary>
        [DataMember]
        public string FileName { get; set; }

        /// <summary>
        /// Размер файла
        /// </summary>
        [DataMember]
        public int FileSize { get; set; }

        /// <summary>
        /// Контент
        /// </summary>
        [DataMember]
        public byte[] Content { get; set; }

        /// <summary>
        /// Карточка
        /// </summary>
        [DataMember]
        public byte[] Card { get; set; }

        /// <summary>
        /// Комментарий
        /// </summary>
        [DataMember]
        public string Comment { get; set; }

        /// <summary>
        /// Признак "Требуется подпись получателя"
        /// </summary>
        [DataMember]
        public bool NeedSign { get; set; }

        /// <summary>
        /// Флаг "Необходимость подтверждения факта приема документа"
        /// </summary>
        [DataMember]
        public bool NeedReceipt { get; set; }
    }
}
