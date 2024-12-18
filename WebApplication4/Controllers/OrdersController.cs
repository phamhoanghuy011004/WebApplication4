using Microsoft.AspNetCore.Mvc;
using WebApplication4.Data;

namespace WebApplication4.Controllers;
[ApiController]
[Route("api/[controller]")]

public class OrdersController : ControllerBase
{
    private readonly AppDbContext _context;

    public OrdersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetOrders()
    {
        var orders = _context.Orders.ToList();
        return Ok(orders.Select(order => new
        {
            order.Id,
            order.OrderDate,
            User = order.User.Name,
            Details = order.OrderDetails.Select(detail => new
            {
                Product = detail.Product.Name,
                detail.Quantity,
                detail.UnitPrice
            })
        }));
    }
}