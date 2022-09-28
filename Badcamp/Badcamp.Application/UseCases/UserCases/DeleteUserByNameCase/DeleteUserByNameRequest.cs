using Badcamp.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.UserCases.DeleteUserCase
{
    public class DeleteUserByNameRequest : IRequest<Response>
    {
        public string UserName { get; set; } = string.Empty;
    }
}
