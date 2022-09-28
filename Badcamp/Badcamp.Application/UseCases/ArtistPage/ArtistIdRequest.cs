using Badcamp.Application.Common;

namespace Badcamp.Application.UseCases.ArtistPage
{
	public class ArtistIdRequest : IRequest<Response>
	{
		public int Id { get; set; }
	}
}