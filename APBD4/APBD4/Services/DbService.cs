using APBD4.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APBD4.Services
{
    public class DbService : IDbService
    {
        private const string ConnString = "Data Source=db-mssql;Initial Catalog=jd;Integrated Security=True";

        public async Task<Book> GetBookByTitle(string title)
        { 
            // Jeżeli musimy przekazać "z zewnątrz" (z kodu) jakiś argument do naszej SQLki
            // należy pamietać żeby realizować to poprzez parametry w celu zabezpieczenia się przed atakiem SQLInjection!!!!
            
            // Poniżej chcę przekazać do SQLki tytuł przekazany przez użytkownika
            // W tym celu, w miejscu gdzie chcę przekazać wartośc korzystam z parametru (rozpoczyna się on od @)
            string sql = "SELECT * FROM Book WHERE Title = @title";

            await using SqlConnection connection = new(ConnString);

            await using SqlCommand comm = new(sql, connection);

            // Następnie przed wykonaniem zapytania na bazie, należy przekazać konkretną wartość, która zostanie wstawiona w miejscu parametru
            // o podanej nazwie
            // Podczas podawania parametru do metody AddWithValue pomijamy już "@"
            comm.Parameters.AddWithValue("title", title);

            await connection.OpenAsync();

            await using SqlDataReader dr = await comm.ExecuteReaderAsync();

            await dr.ReadAsync();


            return new Book
            {
                IdBook = int.Parse(dr["IdBook"].ToString()),
                Title = dr["Title"].ToString()
            };
        }

        public async Task<IList<Book>> GetBookList()
        {
            List<Book> result = new();

            string sql = "SELECT * FROM Book";

            await using SqlConnection connection = new(ConnString);

            await using SqlCommand comm = new(sql, connection);

            await connection.OpenAsync();

            await using SqlDataReader dr = await comm.ExecuteReaderAsync();

            /*
             * 
            if (!dr.HasRows)
            {
                // Logika gdy w bazie nic nie ma
            }
            */

            while (await dr.ReadAsync())
            {
                result.Add(new Book
                {
                    IdBook = int.Parse(dr["IdBook"].ToString()),
                    Title = dr["Title"].ToString()
                });
            }

            await connection.CloseAsync();

            return result;
        }
    }
}
