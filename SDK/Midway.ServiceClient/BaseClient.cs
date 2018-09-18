using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using Midway.ObjectModel.Exceptions;
using Midway.ObjectModel;

namespace Midway.ServiceClient
{
    public class BaseClient
    {
       // private readonly ExchangeServiceClient client;

        #region authorization
       /* 
        public ExchangeServiceClient WebServiceClient
        {
            get { return client; }
        }
        */
        public bool IsAuthorized
        {
            get
            {
                return !string.IsNullOrEmpty(Token);
            }
        }

        public EventHandler<ClientAutorizedEventArgs> Authorized { get; set; }

        public void TakeToken(string token)
        {
            Token = token;
            BoxId = null;
            Authorized?.Invoke(this, new ClientAutorizedEventArgs(token));
        }

        public virtual string Token { get; set; }
        public virtual string BoxId { get; set; }

        public string EncryptedToken
        {
            get; protected set;
        }

        #endregion
       
        protected void CheckAutorized()
        {
            if (!IsAuthorized)
                throw new InvalidOperationException("До выполнения операции необходимо выполнить авторизацию");
        }
        #region обрабочики вызовов

        protected T Invoke<T>(Func<T> action)
        {
            try
            {
                return action();
            }
            catch (FaultException<System.ServiceModel.ExceptionDetail> fe)
            {
                throw new ServerException(ServiceErrorCode.UnexpectedError, null, fe.Detail.ToString(), null, fe);
            }
            catch (FaultException faultException)
            {
                var messageFault = faultException.CreateMessageFault();
                if (messageFault.HasDetail)
                {
                    ServiceErrorFaultContract serviceErrorFaultContract;
                    try
                    {
                        serviceErrorFaultContract = messageFault.GetDetail<ServiceErrorFaultContract>();
                    }
                    catch (SerializationException se)
                    {
                        throw new ServerException(ServiceErrorCode.UnexpectedError, null, se.ToString(), null, faultException);
                    }
                    throw new ServerException(
                        (ServiceErrorCode)Enum.Parse(typeof(ServiceErrorCode), serviceErrorFaultContract.Code),
                        serviceErrorFaultContract.Field,
                        serviceErrorFaultContract.Message,
                        serviceErrorFaultContract.StackTrace);
                }
                else
                    throw new ServerException(ServiceErrorCode.UnexpectedError, null, null, null, faultException);
                // InvalidOperationException("Сервер не передал информацию об ошибке, возможно, неправильно задан адрес сервиса.", faultException);
            }
        }

        /// <summary>
        /// Получить данные аутентификации сотрудника.
        /// </summary>
        /// <param name="employeeOperationCredentials">Данные аутентификации сотрудника.</param>
        /// <returns>Скорректированные данные аутентификации сотрудника.</returns>
        protected EmployeeOperationCredentials TryGetCredentials(EmployeeOperationCredentials employeeOperationCredentials)
        {
            var authToken = employeeOperationCredentials?.AuthToken ?? Token;
            var boxId = employeeOperationCredentials?.BoxAddress ?? BoxId;

            if (authToken == null 
                && boxId == null 
                && employeeOperationCredentials == null)
                return null;

            return new EmployeeOperationCredentials
            {
                AuthToken = authToken,
                BoxAddress = boxId
            };
        }

        /// <summary>
        /// Получить данные аутентификации пользователя.
        /// </summary>
        /// <param name="userOperationCredentials">Данные аутентификации пользователя.</param>
        /// <returns>Скорректированные данные аутентификации пользователя.</returns>
        protected UserOperationCredentials TryGetCredentials(UserOperationCredentials userOperationCredentials)
        {
            var authToken = userOperationCredentials?.AuthToken ?? Token;

            if (authToken == null 
                && userOperationCredentials == null)
                return null;

            return new UserOperationCredentials
            {
                AuthToken = authToken,
            };
        }

        protected TResult Invoke<TResult, TCredentials>(TCredentials credentials, Func<TResult> action)
            where TCredentials : UserOperationCredentials
        {
            credentials.AuthToken = Token;
            return Invoke(action);
        }

        /// <summary>
        /// Вызов метода для зарегистрированного пользователя.
        /// </summary>
        /// <typeparam name="TResult">Тип возвращаемого метода.</typeparam>
        /// <param name="credentials">Данные аутентификации пользователя.</param>
        /// <param name="action">Вызываемый метод.</param>
        /// <returns>Значение вызываемого метода.</returns>
        protected TResult CheckAutorizedInvoke<TResult>(UserOperationCredentials credentials, Func<UserOperationCredentials, TResult> action)
        {
            var correctCredentials = TryGetCredentials(credentials);
            return CheckAutorizedInvoke(() => action(correctCredentials));
        }

        /// <summary>
        /// Вызов метода для зарегистрированного сотрудника.
        /// </summary>
        /// <typeparam name="TResult">Тип возвращаемого метода.</typeparam>
        /// <param name="credentials">Данные аутентификации сотрудника.</param>
        /// <param name="action">Вызываемый метод.</param>
        /// <returns>Значение вызываемого метода.</returns>
        protected TResult CheckAutorizedInvoke<TResult>(EmployeeOperationCredentials credentials, Func<EmployeeOperationCredentials, TResult> action)
        {
            var correctCredentials = TryGetCredentials(credentials);
            return CheckAutorizedInvoke(() => action(correctCredentials));
        }
        
        protected T CheckAutorizedInvoke<T>(Func<T> action)
        {
            return Invoke<T>(() =>
            {
                CheckAutorized();
                return action();
            });
        }

        protected T EndInvoke<T>(Func<IAsyncResult, T> action, IAsyncResult asyncResult)
        {
            return Invoke<T>(() => action(asyncResult));
        }

        #endregion
        
    }
}
