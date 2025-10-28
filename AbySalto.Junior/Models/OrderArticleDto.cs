using AbySalto.Junior.Infrastructure.Entities;

namespace AbySalto.Junior.Models
{
    public class OrderArticleDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ArticleId { get; set; }
        public int Quantity { get; set; }
        public double OrderPrice { get; set; }
    }
}
