using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Базовый класс транспортной накладной.
    /// </summary>
    [DataContract]
    public abstract class TransportWaybillTitleBase
    {
        /// <summary>
        /// Сведения об участниках и операторе электронного документооборота.
        /// </summary>
        [DataMember]
        public InterchangeDescription InterchangeDescription { get; set; }

        /// <summary>
        /// Отметки грузоотправителей, грузополучателей, перевозчиков.
        /// </summary>
        [DataMember]
        public List<TransportWaybillTag> Tags { get; set; }

        /// <summary>
        /// Иные сведения о Транспортной накладной.
        /// </summary>
        [DataMember]
        public InfoFieldFull AdditionalInfo { get; set; }

        /// <summary>
        /// ИД файла - имя сформированного файла (без расширения).
        /// </summary>
        [DataMember]
        public string FileId { get; set; }

        /// <summary>
        /// Версия формата транспортной накладной.
        /// </summary>
        [DataMember(IsRequired = true)]
        public EnumValue FormatVersion { get; set; }
    }
}
