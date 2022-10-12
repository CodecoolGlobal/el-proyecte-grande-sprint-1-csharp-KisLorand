using Badcamp.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.PlaylistCases.CreatePlaylist
{
    internal class CreatePlaylistRequest : IRequest<Response>
    {
        public string Name { get; set; }
    }
}
