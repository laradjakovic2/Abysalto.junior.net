using Microsoft.EntityFrameworkCore;
using AbySalto.Junior.Interfaces;
using AbySalto.Junior.Models;
using AbySalto.Junior.Infrastructure.Database;
using AbySalto.Junior.Infrastructure.Entities;
using AbySalto.Junior.Enums;
using AbySalto.Junior.Extensins;

namespace AbySalto.Junior.Services
{
    public class RestaurantService(ApplicationDbContext context) : IRestaurantService
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<OrderDto>> GetOrdersForUser(int userId, string? sortBy, string? sortOrder)
        {
            var query = _context.Orders.Where(o => o.UserId == userId).OrderBy(sortBy, sortOrder);

            return await query.Select(o => new OrderDto
            {
                Id = o.Id,
                UserId=o.UserId,
                OrderTime= o.OrderTime,
                Phone = o.Phone,
                CurrencyISO = o.CurrencyISO,
                Address = o.Address,
                Status = o.Status,
                Remark = o.Remark,
                TotalPrice = o.TotalPrice,
                PaymentType = o.PaymentType,
                OrderArticles = o.OrderArticles.Select(a => new OrderArticleDto { Id= a.Id, OrderId = a.OrderId, ArticleId = a.ArticleId, Quantity=a.Quantity, OrderPrice=a.OrderPrice}).ToList()
            }).ToListAsync();
        }
        public async Task CreateOrder(CreateOrderDto request)
        {
            var order = new Order
            {
                Id = request.Id,
                UserId = request.UserId,
                OrderTime = request.OrderTime,
                Phone = request.Phone,
                CurrencyISO = request.CurrencyISO,
                Address = request.Address,
                Status = request.Status,
                Remark = request.Remark,
                TotalPrice = await CalculateTotalPriceAsync(request.OrderArticles),
                PaymentType = request.PaymentType,
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            var orderArticles = request.OrderArticles.Select(article => new OrderArticle
            {
                OrderId = order.Id,
                ArticleId = article.ArticleId,
                Quantity = article.Quantity,
                OrderPrice = _context.Articles.First(i => i.Id == article.ArticleId).Price,
            }).ToList();
            _context.OrderArticles.AddRange(orderArticles);
            await _context.SaveChangesAsync();
        }

        public async Task ChangeStatus(int orderId, OrderStatus status)
        {
            var order = await _context.Orders.FindAsync(orderId);

            if (order == null)
            {
                throw new KeyNotFoundException($"Order with ID {orderId} not found.");
            }

            order.Status = status;
            await _context.SaveChangesAsync();
        }

        public async Task<decimal> CalculateTotalPriceAsync(List<CreateOrderArticleDto> orderArticles)
        {
            var articleIds = orderArticles.Select(a => a.ArticleId).ToList();

            var articles = await _context.Articles
                .Where(a => articleIds.Contains(a.Id))
                .ToListAsync();

            var articleDict = articles.ToDictionary(a => a.Id, a => a.Price);

            var totalPrice = orderArticles.Sum(a => a.Quantity * articleDict[a.ArticleId]);

            return totalPrice;
        }
    }
}
