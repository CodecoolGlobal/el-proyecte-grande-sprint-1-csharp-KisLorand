using Badcamp.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.PlaylistCases.DeleteFromPlaylist
{
    public class DeleteFromPlaylistRequest : IRequest<Response>
    {
        public int SongId { get; set; }
        public int PlaylistId { get; set; }
    }
}
