using System.Linq;

namespace Midway.ObjectModel.Extensions
{
    public static class OrganizationRegistrationDataExtensions
    {
        /// <summary>
        /// Получить адрес заданного типа
        /// </summary>
        /// <param name="org"></param>
        /// <param name="addressType"></param>
        /// <returns></returns>
        public static OrganizationAddress GetAddress(this OrganizationRegistrationData org, AddressType addressType)
        {
            return org.Addresses.FirstOrDefault(a => a.AddressType == addressType);
        }

        /// <summary>
        /// Получение общей информации для отображения
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        public static string GetCommonInfo(this OrganizationRegistrationData organization)
        {
            return $"{organization.Name} {organization.Inn}/{organization.Kpp}".Trim('/');
        }

        /// <summary>
        /// Получить ФИО из данных по организации
        /// </summary>
        public static string GetFio(this OrganizationRegistrationData organization)
        {
            return
                string.Join(" ", new[] {organization.LastName, organization.FirstName, organization.MiddleName})
                    .Trim(' ', ',');
        }

        /// <summary>
        /// Пересчитать наименование организации
        /// </summary>
        public static void RecomputeName(this OrganizationRegistrationData organization)
        {
            organization.LegalName = organization.OrganizationType.Code != (int)OrganizationType.Individual
                ? organization.OrganizationType.Code == (int)OrganizationType.LegalEntity
                    ? organization.LegalName
                    : !string.IsNullOrEmpty(organization.GetFio()) && organization.GetFio() != " "
                        ? string.Join(" ", new[] {"ИП", organization.GetFio()}).Trim()
                        : string.Empty
                : null;

            organization.Name = organization.OrganizationType.Code != (int)OrganizationType.Individual
                ? organization.OrganizationType.Code == (int)OrganizationType.LegalEntity
                    ? organization.Name
                    : $"ИП {organization.LastName} {organization.FirstName[0]}.{(!string.IsNullOrEmpty(organization.MiddleName) && organization.MiddleName != " " ? organization.MiddleName[0] + "." : string.Empty)}"
                : organization.GetFio();
        }

        /// <summary>
        /// Получить код ИФНС из данных по организации.
        /// </summary>
        /// <param name="organization">Организация.</param>
        /// <returns>Код ИФНС.</returns>
        public static string GetIfns(this OrganizationRegistrationData organization)
        {
            if (organization.OrganizationType.IsLegalEntity()
                && string.IsNullOrEmpty(organization.Kpp)
                && !organization.Kpp.Equals(" "))
                return organization.Kpp.Substring(0, 4);

            return !organization.OrganizationType.IsIndividual()
                ? organization.Inn.Substring(0, 4)
                : null;
        }
    }
}
