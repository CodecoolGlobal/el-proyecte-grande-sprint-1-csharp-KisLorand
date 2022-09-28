using Badcamp.Application.Common;

namespace Badcamp.Application.UseCases.SongCases
{
    public class DeleteSongRequest : IRequest<Response>
    {
        public int Id { get; set; }
    }
}