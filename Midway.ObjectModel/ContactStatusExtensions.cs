namespace Midway.ObjectModel
{
    public static class ContactStatusExtensions
    {
        /// <summary>
        /// Доступна ли операция отправки запроса авторизации
        /// </summary>
        /// <param name="status">Текущий статус контакта</param>
        public static bool IsRequestAuthAvailable(this ContactStatus status)
        {
            return status == ContactStatus.NonAuthorized
                || status == ContactStatus.AuthRejected;
        }

        /// <summary>
        /// Доступна ли операция принятия запроса авторизации
        /// </summary>
        /// <param name="status">Текущий статус контакта</param>
        public static bool IsAcceptAuthAvailable(this ContactStatus status)
        {
            return status == ContactStatus.IncomingAuthRequest;
        }

        /// <summary>
        /// Доступна ли операция отклонения запроса авторизации
        /// </summary>
        /// <param name="status">Текущий статус контакта</param>
        public static bool IsRejectAuthAvailable(this ContactStatus status)
        {
            return status == ContactStatus.IncomingAuthRequest;
        }

        /// <summary>
        /// Доступна ли операция отзыва запроса авторизации
        /// </summary>
        /// <param name="status">Текущий статус контакта</param>
        public static bool IsCancelAuthAvailable(this ContactStatus status, OrganizationStatus organizationStatus)
        {
            return status == ContactStatus.OutgoingAuthRequest
                && organizationStatus != OrganizationStatus.NonActive;
        }

        /// <summary>
        /// Доступна ли операция прекращения обмена
        /// </summary>
        /// <param name="status">Текущий статус контакта</param>
        public static bool IsDeleteContactAvailable(this ContactStatus status)
        {
            return status == ContactStatus.Active;
        }

        /// <summary>
        /// Доступна ли операция удаления отозванного запроса авторизации
        /// </summary>
        /// <param name="status">Текущий статус контакта</param>
        public static bool IsClearCancelledAuthAvailable(this ContactStatus status)
        {
            return status == ContactStatus.IncomingAuthCancelled;
        }

        /// <summary>
        /// Доступна ли операция отправки документов
        /// </summary>
        /// <param name="status">Текущий статус контакта</param>
        public static bool IsSendDocsAvailable(this ContactStatus status)
        {
            return status == ContactStatus.Active;
        }

        /// <summary>
        /// Доступна ли операция удаления приглашения новой организации
        /// </summary>
        /// <param name="status">Текущий статус контакта</param>
        /// <param name="organizationStatus"></param>
        public static bool IsDeleteInviteAvailable(this ContactStatus status, OrganizationStatus organizationStatus)
        {
            return organizationStatus == OrganizationStatus.NonActive;
        }
    }
}
