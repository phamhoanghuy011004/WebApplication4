using WebApplication4.Models;

namespace WebApplication4.Data;

public static class DataSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (!context.Users.Any())
        {
            var users = new List<User>
            {
                new User { Name = "User 1", Email = "user1@example.com" },
                new User { Name = "User 2", Email = "user2@example.com" }
            };
            context.Users.AddRange(users);
        }

        if (!context.Products.Any())
        {
            var products = new List<Product>();
            for (int i = 1; i <= 30; i++)
            {
                products.Add(new Product { Name = $"Product {i}", Price = i * 10 });
            }
            context.Products.AddRange(products);
        }

        if (!context.Orders.Any())
        {
            var orders = new List<Order>();
            var random = new Random();

            for (int i = 1; i <= 10; i++)
            {
                var order = new Order
                {
                    OrderDate = DateTime.Now.AddDays(-i),
                    UserId = random.Next(1, 3),
                    OrderDetails = new List<OrderDetail>()
                };

                for (int j = 0; j < random.Next(2, 5); j++)
                {
                    order.OrderDetails.Add(new OrderDetail
                    {
                        ProductId = random.Next(1, 31),
                        Quantity = random.Next(1, 10),
                        UnitPrice = random.Next(20, 100)
                    });
                }

                orders.Add(order);
            }

            context.Orders.AddRange(orders);
        }

        context.SaveChanges();
    }
}