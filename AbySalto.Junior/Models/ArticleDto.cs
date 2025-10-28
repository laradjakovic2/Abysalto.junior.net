namespace AbySalto.Junior.Models
{
    public class ArticleDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public required string CurrencyISO { get; set; }
    }
}
