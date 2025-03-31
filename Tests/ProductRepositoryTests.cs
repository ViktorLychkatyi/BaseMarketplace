using BaseMarketplace.Contexts;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BaseMarketplace.Models;
using Dapper;

namespace BaseMarketplace.Tests
{
    [TestFixture]
    public class ProductRepositoryTests
    {
        private ApplicationDbContext _context;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("TestDatabase")
            .Options;

            _context = new ApplicationDbContext(options);
        }

        [Test]
        public void GetProductsOfCategories_ShowGetProductsOfCategories()
        {
            var category1 = new Category
            {
                Name = "Имя категории",
                Products = new List<Product>
                            {
                                new Product
                                {
                                    Name = "Имя товара",
                                    Price = 10,
                                }
                            }
            };

            var category2 = new Category
            {
                Name = "Имя категории 2",
                Products = new List<Product>
                            {
                                new Product
                                {
                                    Name = "Имя товара 2",
                                    Price = 20,
                                }
                            }
            };

            _context?.Categories?.AddRange(category1, category2);
            _context?.SaveChanges();
            var categories = _context.Categories.Include(c => c.Products).ToList();
            Assert.That(categories?.Count, Is.EqualTo(2));
            Assert.That(categories?[0].Name, Is.EqualTo("Category Name"));
            Assert.That(categories?[0].Products?.Count, Is.EqualTo(1));
            Assert.That(categories?[0].Products?.FirstOrDefault()?.Name, Is.EqualTo("Product Name"));
            Assert.That(categories?[0].Products?.FirstOrDefault()?.Price, Is.EqualTo(10));
        }

        [Test]
        public void AddProduct_ShowAddProduct()
        {
            var product1 = new Product
            {
                Name = "Флеш Тест",
                Price = 10,
                CategoryId = 1,
            };

            var product2 = new Product
            {
                Name = "Флеш Тест 2",
                Price = 20,
                CategoryId = 1,
            };

            _context?.Products?.AddRange(product1, product2);
            _context?.SaveChanges();

            var addProducts = _context.Products.Include(p => p.Category).ToList();

            Assert.That(addProducts?.Count, Is.EqualTo(2));
            Assert.That(addProducts?[0].Name, Is.EqualTo("Флеш Тест"));
            Assert.That(addProducts?[0].Price, Is.EqualTo(10));
            Assert.That(addProducts?[0].Category?.Name, Is.EqualTo("Флешки"));
        }

        [Test]
        public void GetAll_ShowGetAll()
        {
            using (var context = new ApplicationDbContext())
            {
                var products = context.Products.ToList();
                Assert.That(products?.Count, Is.EqualTo(2));
            }
        }

        [Test]
        public void GetProductById_ShowProductById()
        {
            var product1 = new Product
            {
                Name = "Флеш Тест",
                Price = 10,
                CategoryId = 1,
            };

            var product2 = new Product
            {
                Name = "Флеш Тест 2",
                Price = 20,
                CategoryId = 1,
            };

            _context?.Products?.AddRange(product1, product2);
            _context?.SaveChanges();
            var product = _context?.Products.FirstOrDefault(p => p.ProductId == 1);
            Assert.That(product?.Name, Is.EqualTo("Флеш Тест"));
            Assert.That(product?.Price, Is.EqualTo(10));
        }

        [Test]
        public void UpdateProduct_ShowUpdateProduct()
        {
            var product1 = new Product
            {
                Name = "Флеш Тест",
                Price = 10,
                CategoryId = 1,
            };

            var product2 = new Product
            {
                Name = "Флеш Тест 2",
                Price = 20,
                CategoryId = 1,
            };

            _context?.Products?.AddRange(product1, product2);
            _context?.SaveChanges();
            var product = _context?.Products.FirstOrDefault(p => p.ProductId == 1);
            product.Name = "Флеш Тест 3";
            product.Price = 30;
            _context?.SaveChanges();
            Assert.That(product?.Name, Is.EqualTo("Флеш Тест 3"));
            Assert.That(product?.Price, Is.EqualTo(30));
        }

        [Test]
        public void DeleteProduct_ShowDeleteProduct()
        {
            var product1 = new Product
            {
                Name = "Флеш Тест",
                Price = 10,
                CategoryId = 1,
            };
            var product2 = new Product
            {
                Name = "Флеш Тест 2",
                Price = 20,
                CategoryId = 1,
            };
            _context?.Products?.AddRange(product1, product2);
            _context?.SaveChanges();
            var product = _context?.Products.FirstOrDefault(p => p.ProductId == 1);
            _context.Products.Remove(product);
            _context?.SaveChanges();
            var products = _context?.Products.ToList();
            Assert.That(products?.Count, Is.EqualTo(1));
        }

        [TearDown]  
        public void TearDown()
        {
            _context?.Database.EnsureDeleted();
            _context?.Dispose();
        }
    }
}
