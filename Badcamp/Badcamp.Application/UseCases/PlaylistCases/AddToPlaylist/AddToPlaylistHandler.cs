using Badcamp.Application.Common;
using Badcamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.PlaylistCases.AddToPlaylist
{
    public class AddToPlaylistHandler : IRequestHandler<AddToPlaylistRequest, Response<Playlist>>
    {
        public IBadcampContext _context { get; set; }
        public AddToPlaylistHandler(IBadcampContext context)
        {
            _context = context;
        }
        public Response<Playlist> Handle(AddToPlaylistRequest message)
        {
            var playlist = _context.Playlists.Find(message.PlaylistId);
            var song = _context.Songs.Find(message.SongId);
            if (playlist == null)
            {
                return Response.Fail<Playlist>("Playlist not found");
            }
            else if (song == null)
            {
                return Response.Fail<Playlist>("Song not found");
            }
            else
            {
                try
                {
                    playlist.Songs.Add(song);
                    _context.SaveChanges();
                    return Response.Ok(playlist);
                }
                catch (Exception e)
                {

                    return Response.Fail<Playlist>(e.Message);
                }

            }
        }
    }
}
