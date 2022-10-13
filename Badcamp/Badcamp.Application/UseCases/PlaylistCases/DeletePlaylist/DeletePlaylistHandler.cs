using Badcamp.Application.Common;
using Badcamp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.PlaylistCases.DeletePlaylist
{
    public class DeletePlaylistHandler : IRequestHandler<DeletePLaylistRequest, Response<Playlist>>
    {

        private IBadcampContext _context;
        public DeletePlaylistHandler(IBadcampContext context)
        {
            _context = context;
        }
        public Response<Playlist> Handle(DeletePLaylistRequest message)
        {
            var playlist = _context.Playlists
                .Include(playlist => playlist.Songs)
                .Where(x => x.Id == message.PlaylistId)
                .FirstOrDefault();
            if (playlist == null)
            {
                return Response.Fail<Playlist>("Playlist not found");
            }
            try
            {
                _context.Playlists.Remove(playlist);
                _context.SaveChanges();
                return Response.Ok(playlist);
            }
            catch (Exception e )
            {

               return Response.Fail<Playlist>(e.Message);
            }
        }
    }
}
