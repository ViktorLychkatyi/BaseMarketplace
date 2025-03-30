using BaseMarketplace.Contexts;

namespace BaseMarketplace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new ApplicationDbContext();
            context.Database.EnsureCreated();

            // === классы репозитоии ===

            var userRepository = new Repositories.UserRepository();
            //userRepository.AddUser("Ян", "yan@email.com", "11111");
            //userRepository.GetAll();
            //userRepository.GetById(1);
            //userRepository.Update(2, "Ян", "yan@email.com", "2222");
            //userRepository.Delete(2);

            var productRepository = new Repositories.ProductRepository();
            //productRepository.AddProduct("Флеш USB", 100, 1);
            //productRepository.GetAll();
            //productRepository.GetById(2);
            //productRepository.Update(2, "Флеш USB", 200, 1);
            //productRepository.Delete(2);

            // === FLUENT API и Data Annotations ===



            // === Способы загрузки данных ===



            // === Dapper ===
        }
    }
}
