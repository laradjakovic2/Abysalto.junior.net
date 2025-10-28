using AbySalto.Junior.Infrastructure.Database;
using AbySalto.Junior.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace AbySalto.Junior.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            await context.Database.MigrateAsync();

            if (!context.Users.Any())
            {
                var user = new User { Name = "Lara", Surname="Đaković", Email = "laradjakovic00@gmail.com" };

                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
            }

            if (!context.Articles.Any())
            {
                var articles = new List<Article>
                {
                    new() {  Name = "Čokolada", Price = 2.5, CurrencyISO="EUR" },
                    new() { Name = "Sok od naranče", Price = 1.8, CurrencyISO="EUR" },
                    new() { Name = "Kruh", Price = 1.2, CurrencyISO="EUR" }
                };

                await context.Articles.AddRangeAsync(articles);
                await context.SaveChangesAsync();
            }
        }
    }
}
