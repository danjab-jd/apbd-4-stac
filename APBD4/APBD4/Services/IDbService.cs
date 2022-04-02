using APBD4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD4.Services
{
    public interface IDbService
    {
        Task<IList<Book>> GetBookList();

        Task<Book> GetBookByTitle(string title);
    }
}
