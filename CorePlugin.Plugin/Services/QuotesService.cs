using CorePlugin.QuoteDb;
using Microsoft.EntityFrameworkCore;
using PluginPolls.PollsDb.Dtos;
using PluginPolls.PollsDb.Exceptions;

namespace PluginPolls.PollsDb.Services;

public class QuotesService
{
    private readonly QuotesContext _db;

    public QuotesService(QuotesContext db) => _db = db;

    public async Task<Quote> GetRandomQuoteAsync()
    {
        var random = new Random();
        var count = await _db.Quotes.CountAsync();
        if (count < 1)
            throw new NoQuotePresentException("No quotes present in the database");
        return await _db.Quotes.Skip(random.Next(count)).FirstAsync();
    }

    public async Task<Quote> AddQuote(QuoteDto quoteDto, Guid userId, string username)
    {
        var quoteAlreadyExists = _db.Quotes.Any(x => x.QuoteText == quoteDto.QuoteText.Trim());
        if (quoteAlreadyExists)
            throw new QuoteAlreadyExistsException("Quote already exists");

        var quote = new Quote
        {
            QuoteText = quoteDto.QuoteText.Trim(),
            SubmitterUuid = userId,
            SubmittedBy = username,
            SubmitTime = DateTime.Now
        };
        await _db.Quotes.AddAsync(quote);
        await _db.SaveChangesAsync();
        return quote;
    }
}
