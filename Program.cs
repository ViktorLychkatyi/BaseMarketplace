using BaseMarketplace.Models;

namespace BaseMarketplace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MyDbContext())
            {
                var order = context.Orders
                    .Select(o => new
                    {
                        o.OrderId,
                        o.Price,
                        o.ProductId,
                        o.UserId
                    })
                    .ToList();

                foreach (var o in order)
                {
                    System.Console.WriteLine($"OrderId: {o.OrderId}\nPrice: {o.Price}\nProductId: {o.ProductId}\nUserId: {o.UserId}\n");
                }
            }
        }
    }
}
