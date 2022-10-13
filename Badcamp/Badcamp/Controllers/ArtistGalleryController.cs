
using Badcamp.Application;
using Badcamp.Application.UseCases.ArtistGalleryCases;
﻿using Badcamp.Domain.Entities;
using Badcamp.Models;
using Badcamp.Services;
using Microsoft.AspNetCore.Mvc;



namespace Badcamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistGalleryController : ControllerBase
    {
        private IBadcampContext _context;

        private ILogger<ArtistGalleryController> _logger;
        public ArtistGalleryController(ILogger<ArtistGalleryController> logger, IBadcampContext context)
        {
            _context = context; 
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IReadOnlyList<ArtistListItemDto>> GetAllArtist()
        {
            var request = new GetAllArtistsHandlerRequest();
            var handler = new GetAllArtistsHandler(_context);
            var response = handler.Handle(request);
            if (response.Failure)
            {
                _logger.LogError(response.Error);
                return BadRequest(response.Error);
            }
            _logger.LogInformation("user received");
            return Ok(response.Value);
        }

 
    }
}
