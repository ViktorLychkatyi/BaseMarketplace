using BaseMarketplace.Contexts;
using Microsoft.Data.SqlClient;

namespace BaseMarketplace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new ApplicationDbContext();
            context.Database.EnsureCreated();

            // === классы репозитоии ===

            //var userRepository = new Repositories.UserRepository();
            //userRepository.AddUser("", "yan@email.com", "11111");
            //userRepository.GetAll();
            //userRepository.GetById(1);
            //userRepository.Update(2, "Ян", "yan@email.com", "2222");
            //userRepository.Delete(2);

            //var productRepository = new Repositories.ProductRepository();
            //productRepository.AddProduct("Флеш USB", 100, 1);
            //productRepository.GetAll();
            //productRepository.GetById(2);
            //productRepository.Update(2, "Флеш USB", 200, 1);
            //productRepository.Delete(2);

            // === FLUENT API, Data Annotations, HP, SP ===

            //string connectionString = "Server=localhost;Database=PeopleHobbies;Trusted_Connection=True;TrustServerCertificate=True;";

            //using (var connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    string sql = @"
            //    CREATE PROCEDURE GetProductsOfCategories
            //    AS
            //    BEGIN
            //        SELECT p.ProductId, p.Name, c.Name AS CategoryName
            //        FROM Product p
            //        JOIN ProductCategories pc ON p.ProductID = pc.ProductCategoryID
            //        JOIN Category c ON pc.ProductCategoryID = c.CategoryID
            //    END
            //    ";

            //    using (var command = new SqlCommand(sql, connection))
            //    {
            //        command.ExecuteNonQuery();
            //        Console.WriteLine("Хранимая процедура 'GetProductsOfCategories' была успешно создана.");
            //    }
            //}

            // === Способы загрузки данных ===




            // === Dapper ===
        }
    }
}
