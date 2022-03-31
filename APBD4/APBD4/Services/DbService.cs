using APBD4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD4.Services
{
    public class DbService : IDbService
    {
        public Task<IList<Book>> GetBookList()
        {
            throw new NotImplementedException();
        }
    }
}
