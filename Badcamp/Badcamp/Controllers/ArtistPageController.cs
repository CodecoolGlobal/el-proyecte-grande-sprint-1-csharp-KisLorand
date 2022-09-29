using Badcamp.Domain.Entities;
using Badcamp.Models;
using Badcamp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Badcamp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ArtistPageController : ControllerBase
	{
		private ArtistPageService _artistPageService;
		public ArtistPageController(ArtistPageService artistPageservice)
		{
			_artistPageService = artistPageservice;
		}

		[HttpGet]
		public ActionResult<IList<Artist>> GetAllArtists()
		{
			var artists = _artistPageService.GetAll();
			return Ok(artists);
		}

		[HttpGet("{id}")]
		public ActionResult<Artist> GetOneArtist([FromRoute] int id)
		{
			Artist artist = _artistPageService.GetOne(id);
			return Ok(artist);
		}

		[HttpPost]
		public ActionResult<IList<Artist>> AddArtist([FromBody] Artist newArtist)
		{
			Artist addedArtist = _artistPageService.Add(newArtist);
			return Ok(_artistPageService.GetAll());
		}

		[HttpPut("{id}")]
		public ActionResult<Artist> UpdateArtist([FromRoute] int id, [FromBody] Artist newArtistData)
		{
			Artist updatedArtist = _artistPageService.Update(id, newArtistData);
			return Ok(updatedArtist);
		}
	}
}
