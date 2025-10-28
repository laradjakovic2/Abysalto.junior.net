using AbySalto.Junior.Enums;

namespace AbySalto.Junior.Models
{
    public class CreateOrderDto
    {
        public int UserId { get; set; }
        public required DateTime OrderTime { get; set; }
        public PaymentType PaymentType { get; set; }
        public required string Address { get; set; }
        public required string Phone { get; set; }
        public string? Remark { get; set; }

        public required string CurrencyISO { get; set; }

        public List<CreateOrderArticleDto> OrderArticles { get; set; } = [];
    }
}
