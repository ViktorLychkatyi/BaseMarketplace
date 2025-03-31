using BaseMarketplace.Contexts;
using BaseMarketplace.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseMarketplace.Repositories
{
    public class ProductRepository
    {
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

        public void Update(int product_id, string name, decimal price, int category_id)
        {
            using (var context = new ApplicationDbContext())
            {
                var product = new Product { ProductId = product_id, Name = name, Price = price, CategoryId = category_id };

                context.Products.Update(product);
                context.SaveChanges();

                Console.WriteLine($"Товар {product.Name}, ID: {product.ProductId} обновлен!");
            }
        }

        public void Delete(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var product = context.Products.Find(id);

                context.Products?.Remove(product);
                context.SaveChanges();

                Console.WriteLine($"Товар {product.Name} удален!");
            }
        }
    }
}
