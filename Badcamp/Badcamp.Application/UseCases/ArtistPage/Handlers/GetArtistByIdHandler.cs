using Badcamp.Application.Common;
using Badcamp.Application.UseCases.ArtistPage.Requests;
using Badcamp.Domain.Entities;
using Badcamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.ArtistPage.Handlers
{
	public class GetArtistByIdHandler : IRequestHandler<ArtistIdRequest, Response<Artist>>
	{
		private ArtistStorage _storage;
		public GetArtistByIdHandler(ArtistStorage storage)
		{
			_storage = storage;
		}
		public Response<Artist> Handle(ArtistIdRequest message)
		{
			Artist artist;
			try
			{
				artist = _storage.GetArtist(message.Id);
				if (artist == null)
				{
					return Response.Fail<Artist>("Artist not found");
				}
				return Response.Ok(artist);
			}
			catch (Exception e)
			{
				return Response.Fail<Artist>(e.Message);

			}
		}
	}
}
