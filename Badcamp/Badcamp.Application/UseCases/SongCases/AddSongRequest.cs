using Badcamp.Application.Common;
using Badcamp.Domain.Entities;
using Badcamp.Models;


namespace Badcamp.Application.UseCases.SongCases
{
    public class AddSongRequest : IRequest<Response>
    {
        public string ArtistId { get; set; }
        public List<int> GenreList { get; set; }
        public Song NewSong { get; set; } = new Song();
    }
}