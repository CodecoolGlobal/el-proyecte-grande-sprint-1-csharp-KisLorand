using Badcamp.Application.Common;
using Badcamp.Models;


namespace Badcamp.Application.UseCases.SongCases
{
    public class AddSongRequest : IRequest<Response>
    {
        public Song NewSong { get; set; } = new Song();
    }
}