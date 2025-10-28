using AbySalto.Junior.Enums;
using AbySalto.Junior.Models;

namespace AbySalto.Junior.Interfaces
{
    public interface IRestaurantService
    {
        public Task<List<OrderDto>> GetOrdersForUser(int userId, string? sortBy, string? sortOrder);
        public Task CreateOrder(CreateOrderDto request);

        public Task ChangeStatus(int orderId, OrderStatus status);

        public Task<double> CalculateTotalPriceAsync(List<CreateOrderArticleDto> orderArticles);
    }
}
