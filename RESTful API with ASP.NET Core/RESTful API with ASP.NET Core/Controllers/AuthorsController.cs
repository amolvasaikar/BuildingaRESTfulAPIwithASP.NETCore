using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RESTful_API_with_ASP.NET_Core.Models;
using RESTful_API_with_ASP.NET_Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTful_API_with_ASP.NET_Core.Controllers
{
    [Route("api/authors")]
    public class AuthorsController : Controller
    {
        private readonly IMapper mapper;
        private readonly ILibraryRepository _libraryRepository;

        public AuthorsController(IMapper mapper , ILibraryRepository libraryRepository)
        {
            this.mapper = mapper;
            this._libraryRepository = libraryRepository;
        }
        [HttpGet()]
        public IActionResult GetAuthors()
        {
            var authorsFromRepo = _libraryRepository.GetAuthors();

            var authors = mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo);
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthor(Guid id)
        {
            var authorFromRepo = _libraryRepository.GetAuthor(id);

            if (authorFromRepo == null)
            {
                return NotFound();
            }

            var author = mapper.Map<AuthorDto>(authorFromRepo);
            return Ok(author);
        }
    }
}
