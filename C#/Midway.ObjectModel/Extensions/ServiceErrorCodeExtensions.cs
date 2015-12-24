using Midway.ObjectModel.Exceptions;

namespace Midway.ObjectModel.Extensions
{
    public static class ServiceErrorCodeExtensions
    {
        /// <summary>
        /// Является ли ошибка Ошибкой при работе с контактами
        /// </summary>
        /// <param name="error"></param>
        public static bool IsContactError(this ServiceErrorCode error)
        {
            return error == ServiceErrorCode.ContactListError
                   || error == ServiceErrorCode.ContragentIsNotAuthorized
                   || error == ServiceErrorCode.ContactIsNotAuthorized
                   || error == ServiceErrorCode.ContactIsAlreadyAuthorized
                   || error == ServiceErrorCode.ContactAuthIsAlreadyRequested
                   || error == ServiceErrorCode.ContactHasRejectedAuth
                   || error == ServiceErrorCode.ContactAuthRequestNotFound
                   || error == ServiceErrorCode.OrganizationMustBeActive
                   || error == ServiceErrorCode.ContactAuthIsRejected;
        }
    }
}
