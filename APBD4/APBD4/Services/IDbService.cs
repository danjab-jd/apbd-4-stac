using APBD4.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APBD4.Services
{
    public interface IDbService
    {
        Task<IList<Book>> GetBookList();
    }
}
