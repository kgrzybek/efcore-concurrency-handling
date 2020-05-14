using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DDD.EF.OptimisticConcurrency.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly OrdersContext _ordersContext;

        public OrdersController(OrdersContext ordersContext)
        {
            _ordersContext = ordersContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderLine(AddOrderLineRequest request)
        {
            var orderId = Guid.Parse("33d4201c-4a8e-40a2-ae1d-50bc64097085");
            
            var order = await _ordersContext.Orders.FindAsync(orderId);
            
            Thread.Sleep(3000);

            order.AddOrderLine(request.ProductCode);

            await _ordersContext.SaveChangesAsync();

            return Ok();
        }
    }
}
