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
                    SubmitterUuid = new Guid("00000000-0000-0000-0000-000000000000"),
                    SubmittedBy = "Tops",
                    SubmitTime = DateTime.Now
                },
                new Quote
                {
                    QuoteId = 2,
                    QuoteText = "Wir sand lost, er sand lost, es ist die perfekte Symbiose!",
                    SubmitterUuid = new Guid("00000000-0000-0000-0000-000000000000"),
                    SubmittedBy = "Loata",
                    SubmitTime = DateTime.Now
                },
                new Quote
                {
                    QuoteId = 3,
                    QuoteText = "Âcht",
                    SubmitterUuid = new Guid("00000000-0000-0000-0000-000000000000"),
                    SubmittedBy = "Tops",
                    SubmitTime = DateTime.Now
                },
                new Quote
                {
                    QuoteId = 4,
                    QuoteText = "Do you need a We-e-ee?",
                    SubmitterUuid = new Guid("00000000-0000-0000-0000-000000000000"),
                    SubmittedBy = "Loata",
                    SubmitTime = DateTime.Now
                },
                new Quote
                {
                    QuoteId = 5,
                    QuoteText = "I gib da glei so a Backpfeife!",
                    SubmitterUuid = new Guid("00000000-0000-0000-0000-000000000000"),
                    SubmittedBy = "Andi",
                    SubmitTime = DateTime.Now
                },
                new Quote
                {
                    QuoteId = 5,
                    QuoteText = "I gib da glei so a Backpfeife!",
                    SubmitterUuid = new Guid("00000000-0000-0000-0000-000000000000"),
                    SubmittedBy = "Andi",
                    SubmitTime = DateTime.Now
                }
            );
        }
    }
}
