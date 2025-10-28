using AbySalto.Junior.Infrastructure.Entities;

namespace AbySalto.Junior.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Email { get; set; }
    }
}
