using Microsoft.EntityFrameworkCore;

namespace CorePlugin.QuoteDb;

public class QuotesContext : DbContext
{
    public QuotesContext(DbContextOptions options) : base(options) { }

    public DbSet<Quote> Quotes { get; set; } = null!;
}
