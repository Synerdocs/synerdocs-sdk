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
            if (Authorized != null)
                Authorized(this, new ClientAutorizedEventArgs(token));
        }

        public virtual string Token { get; set; }

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

        protected TResult Invoke<TResult, TCredentials>(TCredentials credentials, Func<TResult> action)
            where TCredentials : UserOperationCredentials
        {
            credentials.AuthToken = Token;
            return Invoke(action);
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
