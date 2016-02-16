using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Midway.ServiceClient
{
    public class PerformanceCounterInterceptorInserter : IEndpointBehavior 
    {
        internal readonly PerformanceCounterInterceptor performanceCounterInterceptor;

        public PerformanceCounterInterceptorInserter(string[] operations)
        {
            performanceCounterInterceptor = new PerformanceCounterInterceptor(operations);
        }

        public void Validate(ServiceEndpoint endpoint)
        {
            // do nothing
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(performanceCounterInterceptor);
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            // do nothing
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
            // do nothing
        }
    }
}