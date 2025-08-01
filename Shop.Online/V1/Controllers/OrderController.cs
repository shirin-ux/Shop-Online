﻿using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.DTOs;
using Shop.Application.Extention;
using Shop.Application.IServices;
using Shop.Infrastructure.ExternalServices;


namespace Shop.Online.V1.Controllers
{

    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
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
            await _placeOrderService.PlaceOrder(order.MapToOrder());
            return Ok();
        }
    }
}
