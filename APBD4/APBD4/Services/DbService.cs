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
            string sql = "SELECT * FROM Book WHERE Title = @title";

            await using SqlConnection connection = new(ConnString);

            await using SqlCommand comm = new(sql, connection);

            comm.Parameters.AddWithValue("title", title);

            await connection.OpenAsync();

            await using SqlDataReader dr = await comm.ExecuteReaderAsync();

            await dr.ReadAsync();

            return new()
            {
                IdBook = int.Parse(dr["IdBook"].ToString()),
                Title = dr["Title"].ToString()
            };
        }

        public async Task<IList<Book>> GetBooksListAsync()
        {
            List<Book> result = new();

            string sql = "SELECT * FROM Book";

            await using SqlConnection connection = new(ConnString);

            await using SqlCommand comm = new(sql, connection);

            await connection.OpenAsync();

            await using SqlDataReader dr = await comm.ExecuteReaderAsync();

            //if (!dr.HasRows)
            //{
            //    // Logika gdy zapytanie nic nie zwróciło
            //}

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
