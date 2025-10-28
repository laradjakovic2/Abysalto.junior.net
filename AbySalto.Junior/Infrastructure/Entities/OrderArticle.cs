namespace AbySalto.Junior.Infrastructure.Entities
{
    public class OrderArticle
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ArticleId { get; set; }
        public int Quantity { get; set; }
        public decimal OrderPrice { get; set; }

        public Order? Order { get; set; }
        public Article? Article { get; set; }
    }
}
