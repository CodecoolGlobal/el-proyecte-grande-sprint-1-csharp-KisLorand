using Badcamp.Application.Common;
using Badcamp.Models;
using Badcamp.Services;

namespace Badcamp.Application.UseCases.SongCases
{
    public class AddSongHandler : IRequestHandler<AddSongRequest, Response<Song>>
    {
        readonly ISongService _songService;
        public AddSongHandler(ISongService songService)
        {
            _songService = songService;
        }

        public Response<Song> Handle(AddSongRequest message)
        {
            Song song;
            try
            {
                song = _songService.AddSong(message.NewSong);
                if (song == null)
                {
                    return Response.Fail<Song>("Song could not be added.");
                }
                return Response.Ok(song);
            }
            catch (Exception e)
            {
                return Response.Fail<Song>(e.Message);
            }
        }
    }
}
