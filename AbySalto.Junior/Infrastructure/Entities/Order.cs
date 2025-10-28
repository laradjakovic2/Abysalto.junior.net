using AbySalto.Junior.Enums;


namespace AbySalto.Junior.Infrastructure.Entities;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public OrderStatus Status {get;set;}
    public required DateTime OrderTime { get; set; }
    public PaymentType PaymentType { get; set; }
    public required string Address { get; set; }
    public required string Phone { get; set; }
    public string? Remark { get; set; }
    public double TotalPrice { get; set; }

    public required string CurrencyISO { get; set; }

    public ICollection<OrderArticle> OrderArticles { get; set; } = [];
}



