using BaseMarketplace.Contexts;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Text;

namespace BaseMarketplace
{
    internal class Program
    {
        public void Main(string[] args)
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
            //productRepository.AddProduct("Флеш USB", 100, 1);
            //productRepository.AddProduct("Флеш USB", 100, 1);
            //productRepository.AddProduct("Флеш USB", 100, 1);
            //productRepository.AddProduct("Флеш USB", 100, 1);
            //productRepository.AddProduct("Флеш USB", 100, 1);
            //productRepository.GetAll();
            //productRepository.GetById(2);
            //productRepository.Update(2, "Флеш USB", 200, 1);
            //productRepository.Delete(2);
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

            Console.OutputEncoding = Encoding.Unicode;

            string connectionString = "Server=localhost;Database=Marketplace;Trusted_Connection=True;TrustServerCertificate=True;";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var result = connection.Query("SELECT * FROM Product").ToList();

                foreach (var product in result)
                {
                    Console.WriteLine($"ProductId: {product.ProductId}\nName: {product.Name}\nPrice: {product.Price}\nCategoryId: {product.CategoryId}\n");
                }
            }
        }
    }
}
