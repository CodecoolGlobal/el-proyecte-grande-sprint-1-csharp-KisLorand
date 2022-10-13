using Badcamp.Application.Common;
using Badcamp.Application.UseCases.ArtistPage.Requests;
using Badcamp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.ArtistPage.Handlers
{
	public class GetArtistByUserIdHandler : IRequestHandler<ArtistIdRequest, Response<Artist>>
	{
		private IBadcampContext _context;
		public GetArtistByUserIdHandler(IBadcampContext context)
		{
			_context = context;
		}


		public Response<Artist> Handle(ArtistIdRequest message)
		{
			Artist artist;
			try
			{
				artist = _context.Artists.Include(x => x.User).Where(x => x.User.Id == message.Id).FirstOrDefault();
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
