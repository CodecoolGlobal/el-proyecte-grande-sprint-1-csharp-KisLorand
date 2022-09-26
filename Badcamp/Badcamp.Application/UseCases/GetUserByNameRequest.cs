using Badcamp.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases
{
    public class GetUserByNameRequest : IRequest<Response>
    {
        public string UserName { get; set; } = String.Empty;
    }
}
