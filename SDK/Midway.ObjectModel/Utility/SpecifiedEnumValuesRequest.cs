



/*
 ****************************************************************************************************************
 * WARNING: Do not edit this class. It is automatically generated using T4 and any changes will be overwritten. *
 ****************************************************************************************************************
 */
 
using System.Collections.Generic;
using System.Runtime.Serialization;
using Midway.ObjectModel.Common;

namespace Midway.ObjectModel.Utility
{
    /// <summary>
    /// Запрос на получение указанных значений перечислений.
    /// </summary>
    [DataContract]
	public class SpecifiedEnumValuesRequest : EnumValuesRequest
	{
		/// <summary>
		/// Значения перечисления типа 'Тип записи адреса'.
		/// </summary>
		[DataMember]
		public List<AddressLocationType> AddressLocationTypes { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Тип адреса'.
		/// </summary>
		[DataMember]
		public List<AddressType> AddressTypes { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Коды операций над документом'.
		/// </summary>
		[DataMember]
		public List<DocumentOperationCodes> DocumentOperationCodes { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Тип заявки на издание сертификата'.
		/// </summary>
		[DataMember]
		public List<CertificateIssueRequestType> CertificateIssueRequestTypes { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Статус обработки заявки на издание сертификата'.
		/// </summary>
		[DataMember]
		public List<CertificateIssueStatus> CertificateIssueStatuses { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Статус проверки сертификата'.
		/// </summary>
		[DataMember]
		public List<CertificateValidationStatus> CertificateValidationStatuses { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Тип провайдера облачной ЭП'.
		/// </summary>
		[DataMember]
		public List<CloudProviderType> CloudProviderTypes { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Статус проверки черновика документа'.
		/// </summary>
		[DataMember]
		public List<FormatControlValidationStatus> FormatControlValidationStatuses { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Статус создания усовершенствованной подписи'.
		/// </summary>
		[DataMember]
		public List<EnhancedSignCreateStatus> EnhancedSignCreateStatuses { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Причины неудачной попытки создания усовершенствованной подписи'.
		/// </summary>
		[DataMember]
		public List<EnhancedSignFailedReason> EnhancedSignFailedReasons { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Тип подписанта документа'.
		/// </summary>
		[DataMember]
		public List<SignerType> SignerTypes { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Версия формата титула водителя (сдача груза) транспортной накладной'.
		/// </summary>
		[DataMember]
		public List<TransportWaybillCargoDeliveredTitleFormatVersion> TransportWaybillCargoDeliveredTitleFormatVersions { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Версия формата титула перевозчика транспортной накладной'.
		/// </summary>
		[DataMember]
		public List<TransportWaybillCarrierTitleFormatVersion> TransportWaybillCarrierTitleFormatVersions { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Версия формата титула изменения места доставки транспортной накладной'.
		/// </summary>
		[DataMember]
		public List<TransportWaybillDeliveryPlaceChangeTitleFormatVersion> TransportWaybillDeliveryPlaceChangeTitleFormatVersions { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Версия формата титула грузополучателя транспортной накладной'.
		/// </summary>
		[DataMember]
		public List<TransportWaybillConsigneeTitleFormatVersion> TransportWaybillConsigneeTitleFormatVersions { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Версия формата титула водителя (прием груза) транспортной накладной'.
		/// </summary>
		[DataMember]
		public List<TransportWaybillCargoReceivedTitleFormatVersion> TransportWaybillCargoReceivedTitleFormatVersions { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Версия формата транспортной накладной'.
		/// </summary>
		[DataMember]
		public List<TransportWaybillConsignorTitleFormatVersion> TransportWaybillConsignorTitleFormatVersions { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Тип участника ЭДО транспортной накладной'.
		/// </summary>
		[DataMember]
		public List<TransportWaybillInterchangeParticipantType> TransportWaybillInterchangeParticipantTypes { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Тип экземпляра транспортной накладной'.
		/// </summary>
		[DataMember]
		public List<TransportWaybillCopyType> TransportWaybillCopyTypes { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Тип авторизации контактов'.
		/// </summary>
		[DataMember]
		public List<ContactAuthType> ContactAuthTypes { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Статусы контакта'.
		/// </summary>
		[DataMember]
		public List<ContactStatus> ContactStatuses { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Формат содержимого'.
		/// </summary>
		[DataMember]
		public List<ContentFormat> ContentFormats { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Тип функции, которую выполняет документ'.
		/// </summary>
		[DataMember]
		public List<ExecutedFunction> ExecutedFunctions { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Признак подписи'.
		/// </summary>
		[DataMember]
		public List<SignatureMark> SignatureMarks { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Тип настройки'.
		/// </summary>
		[DataMember]
		public List<SettingType> SettingTypes { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Статус аннулирования документа'.
		/// </summary>
		[DataMember]
		public List<DocumentRevocationStatus> DocumentRevocationStatuses { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Статус организации как абонента EDI'.
		/// </summary>
		[DataMember]
		public List<EdiSubscriberStatus> EdiSubscriberStatuses { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Список наименований полей, доступных для фильтрации сотрудников'.
		/// </summary>
		[DataMember]
		public List<EmployeeFilterFieldNameList> EmployeeFilterFieldNameLists { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Пол'.
		/// </summary>
		[DataMember]
		public List<Gender> Genders { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Тип документа, удостоверяющего личность'.
		/// </summary>
		[DataMember]
		public List<IdentityDocumentType> IdentityDocumentTypes { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Статус выполнения операции'.
		/// </summary>
		[DataMember]
		public List<OperationStatus> OperationStatuses { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Режим получения документооборота'.
		/// </summary>
		[DataMember]
		public List<DocumentFlowResultMode> DocumentFlowResultModes { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Тип документооборота (для фильтрации)'.
		/// </summary>
		[DataMember]
		public List<DocumentFlowType> DocumentFlowTypes { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Типы тегов для документа'.
		/// </summary>
		[DataMember]
		public List<DocumentTagType> DocumentTagTypes { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Режим отправки сообщения черновика'.
		/// </summary>
		[DataMember]
		public List<DraftMessageSendMode> DraftMessageSendModes { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Тип документооборота'.
		/// </summary>
		[DataMember]
		public List<FlowType> FlowTypes { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Статус документооборота получателя'.
		/// </summary>
		[DataMember]
		public List<RecipientFlowStatus> RecipientFlowStatuses { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Статус получения документа'.
		/// </summary>
		[DataMember]
		public List<DocumentDeliveryStatus> DocumentDeliveryStatuses { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Статус получения документа при отправке нескольким получателям'.
		/// </summary>
		[DataMember]
		public List<DocumentMultiDeliveryStatus> DocumentMultiDeliveryStatuses { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Статус подписания документа несколькими получателями'.
		/// </summary>
		[DataMember]
		public List<DocumentMultiSignStatus> DocumentMultiSignStatuses { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Статус подписания документа получателем'.
		/// </summary>
		[DataMember]
		public List<DocumentSignStatus> DocumentSignStatuses { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Тип документа'.
		/// </summary>
		[DataMember]
		public List<DocumentType> DocumentTypes { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Статусы ЭСФ'.
		/// </summary>
		[DataMember]
		public List<InvoiceFlowStatus> InvoiceFlowStatuses { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Статус изменения счета-фактуры'.
		/// </summary>
		[DataMember]
		public List<InvoiceModificationStatus> InvoiceModificationStatuses { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Статус сообщения'.
		/// </summary>
		[DataMember]
		public List<MessageStatus> MessageStatuses { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Критерии для выборки информации по организации'.
		/// </summary>
		[DataMember]
		public List<OrganizationByCriteria> OrganizationByCriterias { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Статус организации в сервисе'.
		/// </summary>
		[DataMember]
		public List<OrganizationStatus> OrganizationStatuses { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Тип организации'.
		/// </summary>
		[DataMember]
		public List<OrganizationType> OrganizationTypes { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Код результата регистрации абонента'.
		/// </summary>
		[DataMember]
		public List<RegistrationResponseCode> RegistrationResponseCodes { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Статус документооборота отправителя'.
		/// </summary>
		[DataMember]
		public List<SenderFlowStatus> SenderFlowStatuses { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Статус доступности использования простой ЭП'.
		/// </summary>
		[DataMember]
		public List<SimpleSignatureAvailabilityStatus> SimpleSignatureAvailabilityStatuses { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Тип квалификации подписи'.
		/// </summary>
		[DataMember]
		public List<SignQualificationType> SignQualificationTypes { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Тип владельца (субъекта) сертификата'.
		/// </summary>
		[DataMember]
		public List<SubjectPersonType> SubjectPersonTypes { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Тип документа'.
		/// </summary>
		[DataMember]
		public List<TitleType> TitleTypes { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Категория сообщения валидации'.
		/// </summary>
		[DataMember]
		public List<ValidationMessageCategory> ValidationMessageCategories { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Статус сообщения валидации'.
		/// </summary>
		[DataMember]
		public List<ValidationMessageStatus> ValidationMessageStatuses { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Формат результата валидации'.
		/// </summary>
		[DataMember]
		public List<ValidationResultFormat> ValidationResultFormats { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Налоговая ставка'.
		/// </summary>
		[DataMember]
		public List<VatRate> VatRates { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Тип оператора составного фильтра'.
		/// </summary>
		[DataMember]
		public List<CompositeFilterOperatorType> CompositeFilterOperatorTypes { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Тип сущности'.
		/// </summary>
		[DataMember]
		public List<EntityType> EntityTypes { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Тип значение, представленного простым текстом'.
		/// </summary>
		[DataMember]
		public List<TextValueType> TextValueTypes { get; set; }

		/// <summary>
		/// Значения перечисления типа 'Тип оператора фильтра'.
		/// </summary>
		[DataMember]
		public List<FilterOperatorType> FilterOperatorTypes { get; set; }
	}
}