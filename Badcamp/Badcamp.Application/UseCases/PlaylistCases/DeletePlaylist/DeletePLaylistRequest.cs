using Badcamp.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.PlaylistCases.DeletePlaylist
{
    internal class DeletePLaylistRequest : IRequest<Response>
    {
        public int PlaylistId { get; set; }
    }
}
