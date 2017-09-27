namespace Midway.ObjectModel.Extensions
{
    /// <summary>
    /// Методы расширения для типа организации.
    /// </summary>
    public static class OrganizationTypeExtensions
    {
        /// <summary>
        /// Юридическое лицо.
        /// </summary>
        /// <param name="organizationType">Тип организации.</param>
        /// <returns><c>true</c>, если тип организации "Юридическое лицо", иначе <c>false</c>.</returns>
        public static bool IsLegalEntity(this EnumValue organizationType)
        {
            return organizationType.Code == (int) OrganizationType.LegalEntity;
        }

        /// <summary>
        /// Физическое лицо.
        /// </summary>
        /// <param name="organizationType">Тип организации.</param>
        /// <returns><c>true</c>, если тип организации "Физическое лицо", иначе <c>false</c>.</returns>
        public static bool IsIndividual(this EnumValue organizationType)
        {
            return organizationType.Code == (int) OrganizationType.Individual;
        }

        /// <summary>
        /// Индивидуальный предприниматель.
        /// </summary>
        /// <param name="organizationType">Тип организации.</param>
        /// <returns><c>true</c>, если тип организации "Индивидуальный предприниматель", иначе <c>false</c>.</returns>
        public static bool IsEntrepreneur(this EnumValue organizationType)
        {
            return organizationType.Code == (int) OrganizationType.IndividualEntrepreneur;
        }

        /// <summary>
        /// Юридическое лицо.
        /// </summary>
        /// <param name="organizationType">Тип организации.</param>
        /// <returns><c>true</c>, если тип организации "Юридическое лицо", иначе <c>false</c>.</returns>
        public static bool IsLegalEntity(this OrganizationType organizationType)
        {
            return organizationType == OrganizationType.LegalEntity;
        }

        /// <summary>
        /// Физическое лицо.
        /// </summary>
        /// <param name="organizationType">Тип организации.</param>
        /// <returns><c>true</c>, если тип организации "Физическое лицо", иначе <c>false</c>.</returns>
        public static bool IsIndividual(this OrganizationType organizationType)
        {
            return organizationType == OrganizationType.Individual;
        }

        /// <summary>
        /// Индивидуальный предприниматель.
        /// </summary>
        /// <param name="organizationType">Тип организации.</param>
        /// <returns><c>true</c>, если тип организации "Индивидуальный предприниматель", иначе <c>false</c>.</returns>
        public static bool IsEntrepreneur(this OrganizationType organizationType)
        {
            return organizationType == OrganizationType.IndividualEntrepreneur;
        }
    }
}
