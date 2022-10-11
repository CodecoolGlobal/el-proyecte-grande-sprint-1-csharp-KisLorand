using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.Common
{
    /// <summary>
    /// Defines a handler for a request
    /// </summary>
    /// <typeparam name="TRequest">The type of request being handled</typeparam>
    /// <typeparam name="TResponse">The type of response from the handler</typeparam>
    public interface IRequestHandler<in TRequest, out TResponse>
        where TRequest : IRequest<Response>
    {
        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        TResponse Handle(TRequest message);
    }

    /// <summary>
    /// Defines a handler for a request without a return value
    /// </summary>
    /// <typeparam name="TRequest">The type of request being handled</typeparam>
    public interface IRequestHandler<in TRequest>
        where TRequest : IRequest
    {
        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="message">The request message</param>
        void Handle(TRequest message);
        void Handle(TRequest message, IConfiguration config);
    }

}
