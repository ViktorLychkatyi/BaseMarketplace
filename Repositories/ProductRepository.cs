using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseMarketplace.Contexts;
using BaseMarketplace.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Dapper;
using System.Data.SqlClient;
using Z.Dapper.Plus;

namespace BaseMarketplace.Repositories
{
    public class ProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void GetProductsOfCategories()
        {
            using var context = new ApplicationDbContext();

            var categories = context.Categories
                .Include(c => c.Products)
                .ToList();

            foreach (var category in categories)
            {
                Console.WriteLine($"Категория: {category.Name}");

                if (category.Products.Any())
                {
                    foreach (var product in category.Products)
                    {
                        Console.WriteLine($"Товар: {product.Name}");
                    }
                }
                else
                {
                    Console.WriteLine(" Нет товаров");
                }
            }
        }

        public void AddProduct(string name, decimal price, int category_id)
        {
            using (var context = new ApplicationDbContext())
            {
                var product = new Product { Name = name, Price = price, CategoryId = category_id };

                context.Products.Add(product);
                context.SaveChanges();

                Console.WriteLine($"Товар {product.Name} добавлен!");
            }
        }

        public void UpdateProduct(int product_id, string name, decimal price, int category_id)
        {
            using (var context = new ApplicationDbContext())
            {
                var product = new Product { ProductId = product_id, Name = name, Price = price, CategoryId = category_id };

                context.Products.Update(product);
                context.SaveChanges();

                Console.WriteLine($"Товар {product.Name}, ID: {product.ProductId} обновлен!");
            }
        }

        public void DeleteProduct(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var product = context.Products.Find(id);

                context.Products?.Remove(product);
                context.SaveChanges();

                Console.WriteLine($"Товар {product.Name} удален!");
            }
        }

        public void GetAll()
        {
            using (var context = new ApplicationDbContext())
            {
                var products = context.Products.ToList();
                foreach (var product in products)
                {
                    Console.WriteLine($"ProductId: {product.ProductId}\nName: {product.Name}\nPrice: {product.Price}\nCategoryId: {product.CategoryId}\n");
                }
            }
        }

        public void GetById(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var product = context.Products.Find(id);
                Console.WriteLine($"ProductId: {product.ProductId}\nName: {product.Name}\nPrice: {product.Price}\nCategoryId: {product.CategoryId}\n");
            }
        }

        // для дапера

        public void Delete(int product_id)
        {
            using (var context = new ApplicationDbContext())
            {
                var connection = context.Database.GetDbConnection();
                connection.Open();

                var sql = "DELETE FROM Product WHERE ProductID = @ProductID";
                connection.Execute(sql, new { ProductID = product_id });

                Console.WriteLine($"Товар с ID {product_id} удален!");
            }
        }

        public void Update(int product_id, string name, decimal price, int category_id)
        {
            using (var context = new ApplicationDbContext())
            {
                var connection = context.Database.GetDbConnection();
                connection.Open();
                var sql = "UPDATE Product SET Name = @Name, Price = @Price, CategoryID = @CategoryID WHERE ProductID = @ProductID";
                connection.Execute(sql, new { ProductID = product_id, Name = name, Price = price, CategoryID = category_id });
                Console.WriteLine($"Товар с ID {product_id} обновлен!");
            }
        }

        public void Create(string name, decimal price, int category_id)
        {
            using (var context = new ApplicationDbContext())
            {
                var connection = context.Database.GetDbConnection();
                connection.Open();
                var sql = "INSERT INTO Product (Name, Price, CategoryID) VALUES (@Name, @Price, @CategoryID)";
                connection.Execute(sql, new { Name = name, Price = price, CategoryID = category_id });
                Console.WriteLine($"Товар {name} добавлен!");
            }
        }

        public void Read(int product_id)
        {
            using (var context = new ApplicationDbContext())
            {
                var connection = context.Database.GetDbConnection();
                connection.Open();
                var sql = "SELECT * FROM Product WHERE ProductID = @ProductID";
                var product = connection.QueryFirstOrDefault<Product>(sql, new { ProductID = product_id });
                Console.WriteLine($"ProductId: {product.ProductId}\nName: {product.Name}\nPrice: {product.Price}\nCategoryId: {product.CategoryId}\n");
            }
        }
    }
}
