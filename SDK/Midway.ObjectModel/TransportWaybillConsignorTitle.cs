using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Титул грузоотправителя транспортной накладной.
    /// </summary>
    [DataContract]
    public class TransportWaybillConsignorTitle : TransportWaybillTitleBase
    {
        /// <summary>
        /// Грузоотправитель.
        /// По XSD схеме элемент обязателен, но т.к он может быть заполнен автоматически из контента документа,
        /// свойство помечено как необязательное.
        /// </summary>
        [DataMember]
        public CounterpartyBase Consignor { get; set; }

        /// <summary>
        /// Грузополучатель.
        /// По XSD схеме элемент обязателен, но т.к он может быть заполнен автоматически из контента документа,
        /// свойство помечено как необязательное.
        /// </summary>
        [DataMember]
        public CounterpartyBase Consignee { get; set; }

        /// <summary>
        /// Описание груза.
        /// </summary>
        [DataMember]
        public CargoDescription CargoDescription { get; set; }

        /// <summary>
        /// Сопроводительные документы.
        /// </summary>
        [DataMember]
        public List<ShippingDocument> ShippingDocuments { get; set; }

        /// <summary>
        /// Указания грузоотправителя.
        /// </summary>
        [DataMember]
        public ConsignorInstructions ConsignorInstructions { get; set; }

        /// <summary>
        /// Прием груза.
        /// </summary>
        [DataMember]
        public CargoOperation CargoReception { get; set; }

        /// <summary>
        /// Сдача груза.
        /// </summary>
        [DataMember]
        public CargoOperation CargoDelivery { get; set; }

        /// <summary>
        /// Условия перевозки.
        /// </summary>
        [DataMember]
        public CarriagePolicies CarriagePolicies { get; set; }

        /// <summary>
        /// Информация о принятии заказа (заявки) к исполнению.
        /// </summary>
        [DataMember]
        public OrderAcceptance OrderAcceptance { get; set; }

        /// <summary>
        /// Перевозчик.
        /// </summary>
        [DataMember]
        public Carrier Carrier { get; set; }

        /// <summary>
        /// Описание транспортных средств.
        /// </summary>
        [DataMember]
        public VehiclesDescription VehiclesDescription { get; set; }

        /// <summary>
        /// Оговорки и замечания перевозчика (при приеме и сдаче груза).
        /// </summary>
        [DataMember]
        public CarrierRemarks CarrierRemarks { get; set; }

        /// <summary>
        /// Прочие условия перевозки.
        /// </summary>
        [DataMember]
        public AdditionalCarriagePolicies AdditionalCarriagePolicies { get; set; }

        /// <summary>
        /// Стоимость услуг перевозчика и порядок расчета провозной платы.
        /// </summary>
        [DataMember]
        public CarriageCostAndPaymentPolicy CarriageCostAndPaymentPolicy { get; set; }

        /// <summary>
        /// Сведения о лицах, подписывающих Транспортную накладную от имени Грузоотправителя.
        /// </summary>
        [DataMember]
        public List<SignerBase> ConsignorSigners { get; set; }

        /// <summary>
        /// Номер и дата транспортной накладной
        /// </summary>
        [DataMember]
        public NumberDate WaybillNumberDate { get; set; }

        /// <summary>
        /// Номер и дата заказа (заявки).
        /// </summary>
        [DataMember]
        public NumberDate OrderNumberDate { get; set; }

        /// <summary>
        /// Номер экземпляра транспортной накладной.
        /// </summary>
        [DataMember]
        public EnumValue CopyType { get; set; }
    }
}
