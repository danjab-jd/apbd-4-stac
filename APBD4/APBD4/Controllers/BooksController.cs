using APBD4.Models;
using APBD4.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IDbService _dbService;

        // Server name: (Localdb)\MSSQLLocalDB

        public BooksController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public async Task<IList<Book>> GetBooks(string orderBy)
        {
            //DbService db = new(); NIEDOBRZE

            return await _dbService.GetBookList();
        }

        [HttpGet("{title}")]
        public async Task<Book> GetBook(string title)
        {
            return await _dbService.GetBookByTitle(title);
        }
    }
}
