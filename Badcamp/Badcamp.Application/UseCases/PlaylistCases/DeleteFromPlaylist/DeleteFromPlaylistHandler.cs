using Badcamp.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.PlaylistCases.DeleteFromPlaylist
{
    public class DeleteFromPlaylistHandler : IRequestHandler<DeleteFromPlaylistRequest, Response<DeleteFromPlaylistRequest>>
    {

        private IBadcampContext _context;
        public DeleteFromPlaylistHandler(IBadcampContext context)
        {
            _context = context;
        }
        public Response<DeleteFromPlaylistRequest> Handle(DeleteFromPlaylistRequest message)
        {
            var song = _context.Songs.Find(message.SongId);
            if (song == null) return Response.Fail<DeleteFromPlaylistRequest>("Song not found.");
            var playlist = _context.Playlists.Find(message.PlaylistId);
            if (playlist == null) return Response.Fail<DeleteFromPlaylistRequest>("Playlist not found.");
            try
            {
                playlist.Songs.Remove(song);
                _context.SaveChanges();
                return Response.Ok(message);
            }
            catch (Exception e)
            {
                return Response.Fail<DeleteFromPlaylistRequest>(e.Message);
            }
        }
    }
}
