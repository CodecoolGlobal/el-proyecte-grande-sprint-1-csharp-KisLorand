using Badcamp.Application.Common;
using Badcamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.PlaylistCases.CreatePlaylist
{
    public class CreatePlaylistHandler : IRequestHandler<CreatePlaylistRequest, Response<CreatePlaylistRequest>>
    {

        private IBadcampContext _context;
        public CreatePlaylistHandler(IBadcampContext context)
        {
            _context = context;
        }
        public Response<CreatePlaylistRequest> Handle(CreatePlaylistRequest message)
        {
            var playlist = new Playlist();
            try
            {
                var user = _context.Users.Find(message.UserId);
                playlist.User = user;
                playlist.Name = message.Name;
                _context.Playlists.Add(playlist);
                _context.SaveChanges();
                return Response.Ok(message);
            }
            catch (Exception e)
            {

                return Response.Fail<CreatePlaylistRequest>(e.Message);
            }
        }
    }
}
