using Badcamp.Application.Common;
using Badcamp.Domain.Entities;
using Badcamp.Models;
using Badcamp.Services;

namespace Badcamp.Application.UseCases.SongCases
{
    public class AddSongHandler : IRequestHandler<AddSongRequest, Response>
    {
        private IBadcampContext _context;

        public AddSongHandler(IBadcampContext context)
        {
            _context = context;
        }

        public Response Handle(AddSongRequest message)
        {

            try
            {
                var artist = _context.Artists.Find(message.ArtistId);
                if (artist != null)
                {
                    message.NewSong.Artist = artist;
                }

                var genres = new HashSet<Genre>();
                foreach (int genreId in message.GenreList)
                {
                    var genreIter = _context.Genres.Find(genreId);
                    if (genreIter != null)
                    {
                        genres.Add(genreIter);
                    }
                }
                message.NewSong.Genres = genres;

                _context.Songs.Add(message.NewSong);
                _context.SaveChanges();
                return Response.Ok();
            }
            catch (Exception e)
            {
                return Response.Fail<Song>(e.Message);
            }
        }
    }
}
