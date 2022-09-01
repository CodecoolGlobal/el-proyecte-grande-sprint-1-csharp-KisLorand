﻿using Badcamp.Models;
using Badcamp.Services;
using Microsoft.AspNetCore.Mvc;

namespace Badcamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistGalleryController
    {

        private ArtistGalleryService _artistGalleryService;
        public ArtistGalleryController(ArtistGalleryService artistGalleryService)
        {
            _artistGalleryService = artistGalleryService;
        }

        [HttpGet]
        public IList<ArtistModel> GetAllArtist()
        {
            return _artistGalleryService.GetAllArtists();
        }

        [HttpGet()]
        [Route("SearchArtistByName/{name}")]
        public ArtistModel SearchArtist([FromRoute] string name)
        {
            return _artistGalleryService.GetArtistByName(name);
        }

        [HttpGet]
        [Route("FilterArtistByGenre/{genre}")]
        public IList<ArtistModel> FilterArtistByGenre([FromRoute] Genre genre)
        {
            return _artistGalleryService.FilterArtistsByGenre(genre);
        }

 
    }
}
