using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Тип настройки.
    /// </summary>
    [DataContract]
    public enum SettingType
    {
        /// <summary>
        /// Получение новостей.
        /// </summary>
        [EnumMember]
        [Description("Получение новостей")]
        NewsReceive = 0,

        /// <summary>
        /// Получение уведомлений о событиях.
        /// </summary>
        [EnumMember]
        [Description("Получение уведомлений о событиях")]
        NotificationReceive = 1,

        /// <summary>
        /// Получение уведомлений о старых документах.
        /// </summary>
        [EnumMember]
        [Description("Получение уведомлений о старых документах")]
        DocumentsNotificationReceive = 2,

        /// <summary>
        /// Возможность отправки документов.
        /// </summary>
        [EnumMember]
        [Description("Возможность отправки документов")]
        SendingDocuments = 3,

        /// <summary>
        /// Возможность отправки документов без подписи.
        /// </summary>
        [EnumMember]
        [Description("Возможность отправки документов без подписи")]
        SendingUnsigned = 4,

        /// <summary>
        /// Возможность пересылки документов.
        /// </summary>
        [EnumMember]
        [Description("Возможность пересылки документов")]
        SendingForward = 5,

        /// <summary>
        /// Возможность внутреннего обмена между подразделениями.
        /// </summary>
        [EnumMember]
        [Description("Возможность внутреннего обмена между подразделениями")]
        SendingInternal = 6,

        /// <summary>
        /// Возможность согласования товарных накладных.
        /// </summary>
        [EnumMember]
        [Description("Возможность согласования товарных накладных")]
        WaybillApproval = 7,

        /// <summary>
        /// Возможность согласования актов.
        /// </summary>
        [EnumMember]
        [Description("Возможность согласования актов")]
        ActOfWorkApproval = 8,

        /// <summary>
        /// Возможность согласования счетов-фактур.
        /// </summary>
        [EnumMember]
        [Description("Возможность согласования счетов-фактур")]
        InvoiceApproval = 9,

        /// <summary>
        /// Возможность согласования неформализованных документов.
        /// </summary>
        [EnumMember]
        [Description("Возможность согласования неформализованных документов")]
        UntypedApproval = 10,

        /// <summary>
        /// Для организации настроен и развёрнут Сервис интеграции.
        /// </summary>
        [EnumMember]
        [Description("Для организации настроен и развёрнут Сервис интеграции")]
        IntegrationService = 11,

        /// <summary>
        /// Организации доступна опция конвертации файлов в формализованные документы.
        /// </summary>
        [EnumMember]
        [Description("Организации доступна опция конвертации файлов в формализованные документы")]
        ConversionService = 12,

        /// <summary>
        /// Возможность запроса подтверждения о получении документа.
        /// </summary>
        [EnumMember]
        [Description("Возможность запроса подтверждения о получении документа")]
        ConfirmReceiptRequest = 13,

        /// <summary>
        /// Возможность обмена с физическими лицами.
        /// </summary>
        [EnumMember]
        [Description("Возможность обмена с физическими лицами")]
        ExchangeWithIndividual = 14,

        /// <summary>
        /// Возможность перемещения документов.
        /// </summary>
        [EnumMember]
        [Description("Возможность перемещения документов")]
        MovingDocuments = 15,

        /// <summary>
        /// Возможность использования простой ЭП.
        /// </summary>
        [EnumMember]
        [Description("Возможность использования простой ЭП")]
        SimpleSignature = 16,

        /// <summary>
        /// Возможность простановки тегов.
        /// </summary>
        [EnumMember]
        [Description("Возможность простановки тегов")]
        TagEdit = 17,

        /// <summary>
        /// Автоподстановка получателей документа.
        /// </summary>
        [EnumMember]
        [Description("Автоподстановка получателей документа")]
        RecipientsAutoFill = 18,

        /// <summary>
        /// Признак вывода полей для дополнительной информации (ИнфоПол\ИнфоПолстр) при печати документов
        /// и веб-клиента и генерации PDF файлов для скачивания.
        /// </summary>
        [EnumMember]
        [Description("Признак вывода полей для дополнительной информации")]
        InfoFieldPdfEnabled = 19,

        /// <summary>
        /// Электронный факторинг.
        /// </summary>
        [EnumMember]
        [Description("Электронный факторинг")]
        Factoring = 20,

        /// <summary>
        /// Обмен EDI-сообщениями.
        /// </summary>
        [EnumMember]
        [Description("Обмен EDI-сообщениями")]
        Edi = 21,
    }
}
