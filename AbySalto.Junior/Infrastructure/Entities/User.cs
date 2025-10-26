namespace AbySalto.Junior.Infrastructure.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int Surname { get; set; }

        public ICollection<Order> Orders { get; set; } = [];

    }
}
