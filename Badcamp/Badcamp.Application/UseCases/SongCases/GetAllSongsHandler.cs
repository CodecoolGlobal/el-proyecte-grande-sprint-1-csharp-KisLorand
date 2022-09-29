using Badcamp.Application.Common;
using Badcamp.Domain.Entities;
using Badcamp.Models;
using Badcamp.Services;

namespace Badcamp.Application.UseCases.SongCases
{
    public class GetAllSongsHandler : IRequestHandler<GetAllSongsRequest, Response<IReadOnlyList<Song>>>
    {
        ISongService _songService;
        public GetAllSongsHandler(ISongService songService)
        {
            _songService = songService;
        }
        public Response<IReadOnlyList<Song>> Handle(GetAllSongsRequest message)
        {
            IReadOnlyList<Song> songs;
            try
            {
                songs = _songService.GetAllSongs();
                if (songs == null)
                {
                    return Response.Fail<IReadOnlyList<Song>>("No songs wer found");
                }
                return Response.Ok(songs);
            }
            catch (Exception e)
            {
                return Response.Fail<IReadOnlyList<Song>>(e.Message);

            }

        }
    }
}