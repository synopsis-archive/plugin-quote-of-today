using CorePlugin.QuoteDb;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PluginPolls.PollsDb.Dtos;
using PluginPolls.PollsDb.Services;

namespace PluginPolls.PollsDb.Controller;

[ApiController]
[Route("[controller]")]
public class QuotesController : ControllerBase
{
    private readonly QuotesService _dbService;

    public QuotesController(QuotesService service) => _dbService = service;

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<Quote>> GetRandomQuote()
    {
        throw new NotImplementedException();
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Quote>> AddQuoteToDb([FromBody] QuoteDto quoteDto)
    {
        throw new NotImplementedException();
    }
}
