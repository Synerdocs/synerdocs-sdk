



/*
 ****************************************************************************************************************
 * WARNING: Do not edit this class. It is automatically generated using T4 and any changes will be overwritten. *
 ****************************************************************************************************************
 */
 
using System.Runtime.Serialization;

namespace Midway.ObjectModel.Utility
{
    /// <summary>
    /// Запрос на получение всех значений перечислений указанных типов.
    /// </summary>
    [DataContract]
	public class FullEnumValuesRequest : EnumValuesRequest
	{
		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Тип записи адреса'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithAddressLocationTypes { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Тип адреса'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithAddressTypes { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Коды операций над документом'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithDocumentOperationCodes { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Тип заявки на издание сертификата'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithCertificateIssueRequestTypes { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Статус обработки заявки на издание сертификата'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithCertificateIssueStatuses { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Статус проверки сертификата'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithCertificateValidationStatuses { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Тип провайдера облачной ЭП'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithCloudProviderTypes { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Статус проверки черновика документа'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithFormatControlValidationStatuses { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Статус создания усовершенствованной подписи'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithEnhancedSignCreateStatuses { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Причины неудачной попытки создания усовершенствованной подписи'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithEnhancedSignFailedReasons { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Тип подписанта документа'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithSignerTypes { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Версия формата титула водителя (сдача груза) транспортной накладной'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithTransportWaybillCargoDeliveredTitleFormatVersions { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Версия формата титула перевозчика транспортной накладной'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithTransportWaybillCarrierTitleFormatVersions { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Версия формата титула изменения места доставки транспортной накладной'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithTransportWaybillDeliveryPlaceChangeTitleFormatVersions { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Версия формата титула грузополучателя транспортной накладной'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithTransportWaybillConsigneeTitleFormatVersions { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Версия формата титула водителя (прием груза) транспортной накладной'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithTransportWaybillCargoReceivedTitleFormatVersions { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Версия формата транспортной накладной'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithTransportWaybillConsignorTitleFormatVersions { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Тип участника ЭДО транспортной накладной'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithTransportWaybillInterchangeParticipantTypes { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Тип экземпляра транспортной накладной'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithTransportWaybillCopyTypes { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Тип авторизации контактов'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithContactAuthTypes { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Статусы контакта'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithContactStatuses { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Формат содержимого'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithContentFormats { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Тип функции, которую выполняет документ'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithExecutedFunctions { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Признак подписи'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithSignatureMarks { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Тип настройки'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithSettingTypes { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Статус аннулирования документа'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithDocumentRevocationStatuses { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Статус организации как абонента EDI'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithEdiSubscriberStatuses { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Список наименований полей, доступных для фильтрации сотрудников'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithEmployeeFilterFieldNameLists { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Пол'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithGenders { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Тип документа, удостоверяющего личность'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithIdentityDocumentTypes { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Статус выполнения операции'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithOperationStatuses { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Режим получения документооборота'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithDocumentFlowResultModes { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Тип документооборота (для фильтрации)'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithDocumentFlowTypes { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Типы тегов для документа'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithDocumentTagTypes { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Режим отправки сообщения черновика'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithDraftMessageSendModes { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Тип документооборота'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithFlowTypes { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Статус документооборота получателя'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithRecipientFlowStatuses { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Статус получения документа'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithDocumentDeliveryStatuses { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Статус получения документа при отправке нескольким получателям'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithDocumentMultiDeliveryStatuses { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Статус подписания документа несколькими получателями'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithDocumentMultiSignStatuses { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Статус подписания документа получателем'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithDocumentSignStatuses { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Тип документа'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithDocumentTypes { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Статусы ЭСФ'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithInvoiceFlowStatuses { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Статус изменения счета-фактуры'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithInvoiceModificationStatuses { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Статус сообщения'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithMessageStatuses { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Критерии для выборки информации по организации'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithOrganizationByCriterias { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Статус организации в сервисе'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithOrganizationStatuses { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Тип организации'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithOrganizationTypes { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Код результата регистрации абонента'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithRegistrationResponseCodes { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Статус документооборота отправителя'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithSenderFlowStatuses { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Статус доступности использования простой ЭП'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithSimpleSignatureAvailabilityStatuses { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Тип квалификации подписи'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithSignQualificationTypes { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Тип владельца (субъекта) сертификата'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithSubjectPersonTypes { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Тип документа'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithTitleTypes { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Категория сообщения валидации'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithValidationMessageCategories { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Статус сообщения валидации'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithValidationMessageStatuses { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Формат результата валидации'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithValidationResultFormats { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Налоговая ставка'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithVatRates { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Тип оператора составного фильтра'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithCompositeFilterOperatorTypes { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Тип сущности'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithEntityTypes { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Тип значение, представленного простым текстом'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithTextValueTypes { get; set; }

		/// <summary>
		/// <c>true</c>, если требуется получить значения перечисления типа 'Тип оператора фильтра'; иначе - <c>false</c>.
		/// </summary>
		[DataMember]
		public bool WithFilterOperatorTypes { get; set; }
	}
}