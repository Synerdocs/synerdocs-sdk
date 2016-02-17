using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Midway.ServiceClient
{
    public class ApplicationVersionEndpointBehavior : IEndpointBehavior
    {
        public string ApplicationVersionHeaderValue { get; set; }
        
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new ApplicationVersionMessageInspector() { ApplicationVersion = ApplicationVersionHeaderValue });
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }

        public ApplicationVersionEndpointBehavior(string applicationVersionHeaderValue)
        {
            ApplicationVersionHeaderValue = applicationVersionHeaderValue;
        }

    }
}