using Badcamp.Application.Common;
using Badcamp.Domain.Entities;
using Badcamp.Application.UseCases.ArtistPage.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.ArtistPage.Handlers
{
	public class AddArtistHandler : IRequestHandler<ArtistAndIdRequest, Response<Artist>>
	{
		private IBadcampContext _context;
		public AddArtistHandler(IBadcampContext context)
		{
			_context = context;
		}

		public Response<Artist> Handle(ArtistAndIdRequest message)
		{
			Artist artist = message.Artist;
			try
			{
				User user = _context.Users.Find(message.UserId);
				artist.User = user;
				_context.Artists.Add(artist);
				_context.SaveChanges();
				if (artist == null)
				{
					return Response.Fail<Artist>("Artists list not found");
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
