using Microsoft.EntityFrameworkCore;

namespace CorePlugin.QuoteDb;

public class QuotesContext : DbContext
{
    public QuotesContext(DbContextOptions options) : base(options) { }

    public DbSet<Quote> Quotes { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Seed(modelBuilder);
    }

    private void Seed(ModelBuilder builder)
    {
        {
            builder.Entity<Quote>().HasData(
                new Quote
                {
                    QuoteId = 1,
                    QuoteText = "Diomadensuppse",
                    SubmitterUuid = Guid.Parse("00000000-000D0-0000-0000-000000000000"),
                    SubmittedBy = "Tops",
                    SubmitTime = DateTime.Now
                },
                new Quote
                {
                    QuoteId = 2,
                    QuoteText = "Wir sand lost, er sand lost, es ist die perfekte Symbiose!",
                    SubmitterUuid = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                    SubmittedBy = "Loata",
                    SubmitTime = DateTime.Now
                }
            );
        }
    }
}
