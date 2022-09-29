using Badcamp.Application.Common;
using Badcamp.Domain.Entities;
using Badcamp.Models;

namespace Badcamp.Application.UseCases.SongCases
{
    public class UpdateSongRequest : IRequest<Response>
    {
        public int Id { get; set; }
        public Song updateData { get; set; } = new Song();
    }
}
