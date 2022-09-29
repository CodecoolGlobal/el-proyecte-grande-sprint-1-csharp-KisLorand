using Badcamp.Application.Common;
using Badcamp.Domain.Entities;
using Badcamp.Models;
using Badcamp.Services;

namespace Badcamp.Application.UseCases.SongCases
{
    public class GetSongHandler : IRequestHandler<GetSongRequest, Response<Song>>
    {
        readonly ISongService _songService;
        public GetSongHandler(ISongService songService)
        {
            _songService = songService;
        }

        public Response<Song> Handle(GetSongRequest message)
        {
            Song song;
            try
            {
                song = _songService.GetSongById(message.Id);
                if (song == null)
                {
                    return Response.Fail<Song>($"No Song with ID:{message.Id} was found.");
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
