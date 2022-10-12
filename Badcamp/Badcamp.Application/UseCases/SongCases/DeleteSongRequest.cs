using Badcamp.Application.Common;
using Badcamp.Domain.Entities;

namespace Badcamp.Application.UseCases.SongCases
{
    public class DeleteSongRequest : IRequest<Response>
    {
        public Song song { get; set; }
    }
}