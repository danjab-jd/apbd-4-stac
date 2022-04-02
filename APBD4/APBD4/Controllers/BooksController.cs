using APBD4.Models;
using APBD4.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        // GET: localhost:XXXXX/api/books?orderBy=title
        // W tym przypadku wartość dla klucza orderBy pobieramy z tzw. query parameters, które następują po "?" w adresie URL
        // Żeby mapowanie nastąpiło automatycznie, nazwa argumentu metody i klucz w URL muszą być takie same
        // Jeżeli chcemy przekazać więcej query parameters oddzielamy je od siebie "&", np.
        // GET: localhost:XXXXX/api/books?orderBy=title&sortBy=idBook
        [HttpGet]
        public async Task<IList<Book>> GetBooks(string orderBy)
        {
            //DbService db = new(); NIEDOBRZE

            return await _dbService.GetBookList();
        }

        // GET: localhost:XXXXXX/api/books/tytulA
        // GET: localhost:XXXXXX/api/books/tytulB
        // To jest tylko przykład, który nie jest zbyt poprawny RESTowo, więc proszę się tym nie wzorować :)
        [HttpGet("{title}")]
        public async Task<Book> GetBook(string title)
        {
            return await _dbService.GetBookByTitle(title);
        }
    }
}
