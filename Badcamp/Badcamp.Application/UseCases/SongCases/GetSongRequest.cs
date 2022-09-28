using Badcamp.Application.Common;

namespace Badcamp.Application.UseCases.SongCases
{
    public class GetSongRequest : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
