using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RESTful_API_with_ASP.NET_Core.Models;
using RESTful_API_with_ASP.NET_Core.Services;
namespace RESTful_API_with_ASP.NET_Core.Controllers
{
    [Route("api/books")]
    public class BooksController : Controller
    {
        private readonly ILibraryRepository libraryRepository;
        private readonly IMapper mapper;

        public BooksController(ILibraryRepository libraryRepository , IMapper mapper)
        {
            this.libraryRepository = libraryRepository;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
