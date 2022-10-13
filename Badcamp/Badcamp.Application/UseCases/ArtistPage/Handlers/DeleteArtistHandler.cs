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
	public class DeleteArtistHandler : IRequestHandler<ArtistIdRequest, Response<Artist>>
	{
		private IBadcampContext _context;
		public DeleteArtistHandler(IBadcampContext context)
		{
			_context = context;
		}

		public Response<Artist> Handle(ArtistIdRequest message)
		{
			Artist artist;
			try
			{
				artist = _context.Artists.Where(x=>x.Id==message.Id).FirstOrDefault();
				if (artist == null)
				{
					return Response.Fail<Artist>("Artist not found");
				}
				_context.Artists.Remove(artist);
				_context.SaveChanges();
				return Response.Ok(artist);
			}
			catch (Exception ex)
			{
				return Response.Fail<Artist>(ex.Message);
			}
		}
	}
}
