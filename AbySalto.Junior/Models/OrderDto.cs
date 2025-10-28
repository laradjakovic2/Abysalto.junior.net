using AbySalto.Junior.Enums;
using AbySalto.Junior.Infrastructure.Entities;

namespace AbySalto.Junior.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public OrderStatus Status { get; set; }
        public required DateTime OrderTime { get; set; }
        public PaymentType PaymentType { get; set; }
        public required string Address { get; set; }
        public required string Phone { get; set; }
        public string? Remark { get; set; }
        public decimal TotalPrice { get; set; }

        public required string CurrencyISO { get; set; }

        public List<OrderArticleDto> OrderArticles { get; set; } = [];
    }
}
