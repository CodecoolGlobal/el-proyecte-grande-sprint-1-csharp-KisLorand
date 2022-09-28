using Badcamp.Application.Common;
using Badcamp.Models;
using Badcamp.Services;

namespace Badcamp.Application.UseCases.SongCases
{
    public class DeleteSongHandler
    {
        readonly ISongService _songService;
        public DeleteSongHandler(ISongService songService)
        {
            _songService = songService;
        }

        public void Handle(DeleteSongRequest message)
        {
            _songService.DeleteSong(message.Id);
        }
    }
}
