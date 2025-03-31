using BaseMarketplace.Contexts;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Text;
using BaseMarketplace.Models;
using Z.Dapper.Plus;

namespace BaseMarketplace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=localhost;Database=Marketplace;Trusted_Connection=True;TrustServerCertificate=True;";

            using var context = new ApplicationDbContext();
            context.Database.EnsureCreated();

            // === классы репозитоии ===

            var userRepository = new Repositories.UserRepository();
            //userRepository.AddUser("", "yan@email.com", "11111");
            //userRepository.GetAll();
            //userRepository.GetById(1);
            //userRepository.UpdateUser(2, "Ян", "yan@email.com", "2222");
            //userRepository.DeleteUser(2);

            var productRepository = new Repositories.ProductRepository(connectionString);
            //productRepository.AddProduct("Флеш USB", 100, 1);

            //productRepository.AddProduct("Флеш USB", 100, 1);
            //productRepository.AddProduct("Флеш USB", 100, 1);
            //productRepository.AddProduct("Флеш USB", 100, 1);
            //productRepository.AddProduct("Флеш USB", 100, 1);
            //productRepository.AddProduct("Флеш USB", 100, 1);
            //productRepository.GetAll();
            //productRepository.GetById(2);
            //productRepository.UpdateProduct(2, "Флеш USB", 200, 1);
            //productRepository.DeleteProduct(2);
            //productRepository.GetProductsOfCategories();

            // === FLUENT API, Data Annotations, HP, SP ===

            //string connectionString = "Server=localhost;Database=Marketplace;Trusted_Connection=True;TrustServerCertificate=True;";

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

            // === Dapper ===

            //productRepository.Create("Флеш USB", 100, 1);
            //productRepository.Delete(11);
            //productRepository.Update(10, "Флеш USB", 200, 1);
            //productRepository.Read(9);

            //productRepository.GetAll();

            var users = new List<User>()
            {
                new User() { UserId = 8, Name = "Анна", Email = "anna@email.com", Password = "1111"},
                new User() { UserId = 9, Name = "Анастасия", Email = "anastasia@email.com", Password = "1111"},
                new User() { UserId = 10, Name = "Мария", Email = "maria@email.com", Password = "1111"}
            };

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //connection.BulkInsert(users);
                //connection.BulkDelete(users);
                //connection.BulkUpdate(users);
                //connection.BulkMerge(users);
                Console.WriteLine("Успешно сделано");
            }

            userRepository.GetAll();
        }
    }
}
