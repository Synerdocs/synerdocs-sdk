using System.ComponentModel;
using System.Runtime.Serialization;

namespace Midway.ObjectModel
{
    /// <summary>
    /// Тип документа, удостоверяющего личность.
    /// </summary>
    [DataContract]
    public enum IdentityDocumentType
    {
        /// <summary>
        /// Паспорт гражданина СССР.
        /// </summary>
        [EnumMember]
        [Description("Паспорт гражданина СССР")]
        USSRCitizenPassport = 1,

        /// <summary>
        /// Загранпаспорт гражданина СССР.
        /// </summary>
        [EnumMember]
        [Description("Загранпаспорт гражданина СССР")]
        USSRCitizenForeignPassport = 2,

        /// <summary>
        /// Свидетельство о рождении.
        /// </summary>
        [EnumMember]
        [Description("Свидетельство о рождении")]
        BirthCertificate = 3,

        /// <summary>
        /// Удостоверение личности офицера.
        /// </summary>
        [EnumMember]
        [Description("Удостоверение личности офицера")]
        MilitaryOfficerIdentityCard = 4,

        /// <summary>
        /// Справка об освобождении из места лишения свободы.
        /// </summary>
        [EnumMember]
        [Description("Справка об освобождении из места лишения свободы")]
        CertificateOfReleaseFromPrison = 5,

        /// <summary>
        /// Паспорт Минморфлота.
        /// </summary>
        [EnumMember]
        [Description("Паспорт Минморфлота")]
        MinmorflotPassport = 6,

        /// <summary>
        /// Военный билет.
        /// </summary>
        [EnumMember]
        [Description("Военный билет")]
        MilitaryCard = 7,

        /// <summary>
        /// Временное удостоверение, выданное взамен военного билета.
        /// </summary>
        [EnumMember]
        [Description("Временное удостоверение, выданное взамен военного билета")]
        TemporaryСertificateInsteadOfMilitaryCard = 8,

        /// <summary>
        /// Дипломатический паспорт гражданина РФ.
        /// </summary>
        [EnumMember]
        [Description("Дипломатический паспорт гражданина РФ")]
        RussianCitizenDiplomaticPassport = 9,

        /// <summary>
        /// Паспорт иностранного гражданина.
        /// </summary>
        [EnumMember]
        [Description("Паспорт иностранного гражданина")]
        ForeignCitizenPassport = 10,

        /// <summary>
        /// Свидетельство о рассмотрении ходатайства о признании беженцем на территории РФ.
        /// </summary>
        [EnumMember]
        [Description("Свидетельство о рассмотрении ходатайства о признании беженцем на территории РФ")]
        ApplicationForRefugeeStatusCertificate = 11,

        /// <summary>
        /// Вид на жительство в РФ.
        /// </summary>
        [EnumMember]
        [Description("Вид на жительство в РФ")]
        ResidencePermit = 12,

        /// <summary>
        /// Удостоверение беженца.
        /// </summary>
        [EnumMember]
        [Description("Удостоверение беженца")]
        RefugeeCertificate = 13,

        /// <summary>
        /// Временное удостоверение личности гражданина РФ.
        /// </summary>
        [EnumMember]
        [Description("Временное удостоверение личности гражданина РФ")]
        RussianCitizenTemporaryIdentityCard = 14,

        /// <summary>
        /// Разрешение на временное проживание в РФ.
        /// </summary>
        [EnumMember]
        [Description("Разрешение на временное проживание в РФ")]
        TemporaryResidencePermit = 15,

        /// <summary>
        /// Свидетельство о предоставлении временного убежища на территории Российской Федерации.
        /// </summary>
        [EnumMember]
        [Description("Свидетельство о предоставлении временного убежища на территории Российской Федерации")]
        CertificateOfTemporaryAsylum = 18,

        /// <summary>
        /// Паспорт гражданина РФ.
        /// </summary>
        [EnumMember]
        [Description("Паспорт гражданина РФ")]
        RussianCitizenPassport = 21,

        /// <summary>
        /// Загранпаспорт гражданина РФ.
        /// </summary>
        [EnumMember]
        [Description("Загранпаспорт гражданина РФ")]
        RussianCitizenForeignPassport = 22,

        /// <summary>
        /// Свидетельство о рождении, выданное уполномоченным органом иностранного государства.
        /// </summary>
        [EnumMember]
        [Description("Свидетельство о рождении, выданное уполномоченным органом иностранного государства")]
        ForeignCountryBirthCertificate = 23,

        /// <summary>
        /// Удостоверение личности военнослужащего РФ.
        /// </summary>
        [EnumMember]
        [Description("Удостоверение личности военнослужащего РФ")]
        ServicemanIdentityCard = 24,

        /// <summary>
        /// Паспорт моряка.
        /// </summary>
        [EnumMember]
        [Description("Паспорт моряка")]
        SeamanPassport = 26,

        /// <summary>
        /// Военный билет офицера запаса.
        /// </summary>
        [EnumMember]
        [Description("Военный билет офицера запаса")]
        MilitaryReserveOfficerTicket = 27,

        /// <summary>
        /// Иные документы, выдаваемые органами МВД.
        /// </summary>
        [EnumMember]
        [Description("Иные документы, выдаваемые органами МВД")]
        OtherDocument = 91
    }
}
