using Badcamp.Application.Common;
using Badcamp.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Application.UseCases.GenreCases.AddGenre
{
    internal class AddGenreHandler : IRequestHandler<AddGenreRequest, Response<Genre>>
    {

        private IBadcampContext _context;


        private ILogger<AddGenreHandler> _logger;

        public AddGenreHandler(IBadcampContext context, ILogger<AddGenreHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Response<Genre> Handle(AddGenreRequest message)
        {
            var genre = new Genre() { Name = message.Name};
        }
    }
}
