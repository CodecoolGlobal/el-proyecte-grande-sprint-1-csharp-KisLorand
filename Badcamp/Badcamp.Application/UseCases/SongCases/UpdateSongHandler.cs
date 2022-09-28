using Badcamp.Application.Common;
using Badcamp.Models;
using Badcamp.Services;

namespace Badcamp.Application.UseCases.SongCases
{
    public class UpdateSongHandler
    {
        readonly ISongService _songService;
        public UpdateSongHandler(ISongService songService)
        {
            _songService = songService;
        }

        public Response Handle(UpdateSongRequest message)
        {
            try
            {
                _songService.UpdateSong(message.Id, message.updateData);
                return Response.Ok("Song Updated");
            }
            catch (Exception e)
            {
                return Response.Fail<Song>(e.Message);
            }
        }
    }
}
