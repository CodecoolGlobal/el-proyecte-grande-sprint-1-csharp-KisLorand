using Badcamp.Application.Common;
using Badcamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.ArtistPage.UpdateArtist
{
	public class UpdateArtistHandler : IRequestHandler<UpdateArtistRequest, Response<IReadOnlyList<ArtistModel>>>>
	{
		private ArtistStorage _storage;
		public UpdateArtistHandler(ArtistStorage storage)
		{
			_storage = storage;
		}

		public Response<IReadOnlyList<ArtistModel>> Handle(UpdateArtistRequest message)
		{
			throw new NotImplementedException();
		}
	}
}
