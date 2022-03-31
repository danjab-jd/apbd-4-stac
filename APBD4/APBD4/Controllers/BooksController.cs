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

        // (Localdb)\MSSQLLocalDB

        public BooksController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public async Task<IList<Book>> GetBookList(string orderBy)
        {
            //DbService db = new(); NIEDOBRE

            return await _dbService.GetBooksListAsync();
        }

    }
}
