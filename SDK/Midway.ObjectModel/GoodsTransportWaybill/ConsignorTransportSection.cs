using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Midway.ObjectModel.GoodsTransportWaybill
{
    /// <summary>
    /// Реквизиты транспортного раздела товарно-транспортной накладной.
    /// </summary>
    [DataContract]
    public class ConsignorTransportSection
    {
        /// <summary>
        /// Срок доставки груза.
        /// </summary>
        [DataMember]
        public DateTime? DeliveryDeadline { get; set; }

        /// <summary>
        /// Вид перевозки.
        /// </summary>
        [DataMember]
        public string CarriageType { get; set; }

        /// <summary>
        /// Код.
        /// </summary>
        [DataMember]
        public string Code { get; set; }

        /// <summary>
        /// Маршрут.
        /// </summary>
        [DataMember]
        public string Route { get; set; }

        /// <summary>
        /// Номер путевого листа.
        /// </summary>
        [DataMember]
        public string WaybillNumber { get; set; }

        /// <summary>
        /// Информация о регистрации транспортного средства.
        /// </summary>
        [DataMember]
        public RegistrationInfo VehicleRegistration { get; set; }

        /// <summary>
        /// Перевозчик.
        /// </summary>
        [DataMember]
        public CounterpartyBase Carrier { get; set; }

        /// <summary>
        /// Автомобиль.
        /// </summary>
        [DataMember]
        public TransportVehicle Vehicle { get; set; }

        /// <summary>
        /// Заказчик.
        /// </summary>
        [DataMember]
        public CounterpartyBase Customer { get; set; }

        /// <summary>
        /// Плательщик.
        /// </summary>
        [DataMember]
        public CounterpartyBase Payer { get; set; }

        /// <summary>
        /// Водитель.
        /// </summary>
        [DataMember]
        public Driver Driver { get; set; }

        /// <summary>
        /// Прицепы.
        /// </summary>
        [DataMember]
        public List<TransportVehicle> Trailers { get; set; }

        /// <summary>
        /// Пункт погрузки.
        /// </summary>
        [DataMember]
        public LoadingLocation LoadingPlace { get; set; }

        /// <summary>
        /// Пункт разгрузки.
        /// </summary>
        [DataMember]
        public LoadingLocation UnloadingPlace { get; set; }

        /// <summary>
        /// Сведения о грузе.
        /// </summary>
        [DataMember]
        public CargoSection Cargo { get; set; }

        /// <summary>
        /// Прием груза.
        /// </summary>
        [DataMember]
        public CargoTransferOperation CargoReception { get; set; }

        /// <summary>
        /// Сдача груза.
        /// </summary>
        [DataMember]
        public CargoTransferOperation CargoDelivery { get; set; }

        /// <summary>
        /// Сведения о составленных актах.
        /// </summary>
        [DataMember]
        public List<ShippingDocument> Acts { get; set; }

        /// <summary>
        /// Транспортные услуги.
        /// </summary>
        [DataMember]
        public string TransportServices { get; set; }

        /// <summary>
        /// Сведения о погрузочной операции.
        /// </summary>
        [DataMember]
        public CargoLoadingOperation LoadingOperation { get; set; }

        /// <summary>
        /// Сведения о разгрузочной операции.
        /// </summary>
        [DataMember]
        public CargoLoadingOperation UnloadingOperation { get; set; }

        /// <summary>
        /// Сведения об опасном грузе.
        /// </summary>
        [DataMember]
        public string HazardousCargo { get; set; }
    }
}