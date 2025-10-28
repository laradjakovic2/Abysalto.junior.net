using Microsoft.AspNetCore.Mvc;
using AbySalto.Junior.Interfaces;
using AbySalto.Junior.Models;
using AbySalto.Junior.Enums;

namespace AbySalto.Junior.Controllers
{
    [ApiController]
    public class RestaurantController(ILogger<RestaurantController> logger, IRestaurantService restaurantService) : ControllerBase
    {
        private readonly ILogger<RestaurantController> _logger = logger;
        private IRestaurantService _restaurantService { get; set; } = restaurantService;

        [HttpGet("users/{userId}/orders")]
        public async Task<IActionResult> GetAll(
            int userId,
            [FromQuery] string sortBy = "Id",
            [FromQuery] string sortOrder = "asc")
        {
            var result = await _restaurantService.GetOrdersForUser(userId, sortBy, sortOrder);
            return Ok(result);
        }

        [HttpPost("orders")]
        public async Task<IActionResult> CreateOrder(CreateOrderDto order)
        {
            await _restaurantService.CreateOrder(order);
            return Created();
        }

        [HttpPut("orders/{orderId}/status")]
        public async Task<IActionResult> UpdateStatus(int orderId, [FromBody] UpdateOrderStatusDto orderStatus)
        {
            try
            {
                await _restaurantService.ChangeStatus(orderId, orderStatus.Status);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }


}