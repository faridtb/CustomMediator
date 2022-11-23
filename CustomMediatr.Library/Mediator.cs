using CustomMediatr.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMediatr.Library
{
    public class Mediator : IMediator
    {
        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {

            var requestType = request.GetType();

            var requestTypeInterface = requestType.GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequest<>))
                .FirstOrDefault();

            var responseType = requestTypeInterface.GetGenericArguments()[0];

            var genericType = typeof(IRequestHandler<,>).MakeGenericType(requestType, responseType);

            var handler = ServiceProvider.ServiceProvicer.GetService(genericType);

            return (Task<TResponse>)genericType.GetMethod("Handle").Invoke(handler,new object[] { request });

        }
    }
}
