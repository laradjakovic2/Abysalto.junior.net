namespace AbySalto.Junior.Infrastructure.Entities
{
    public class OrderArticle
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ArticleId { get; set; }
        public int Quantity { get; set; }
        public int OrderPrice { get; set; }

        public required Order Order { get; set; }
        public required Article Article { get; set; }
    }
}
