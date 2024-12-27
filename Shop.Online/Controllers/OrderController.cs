using Microsoft.AspNetCore.Mvc;
using Shop.Application.DTOs;
using Shop.Application.Extention;
using Shop.Application.IServices;

namespace Shop.Online.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IPlaceOrderService _placeOrderService;
        public OrderController(IPlaceOrderService placeOrderService)
        {
            _placeOrderService = placeOrderService;
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderDTO order)
        {
            await _placeOrderService.PlaceOrder(OrderMappingExtensions.MapToOrder(order));
            return Ok();
        }
    }
}
