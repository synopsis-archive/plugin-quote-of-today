using Core.AuthLib;
using CorePlugin.QuoteDb;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PluginPolls.PollsDb.Dtos;
using PluginPolls.PollsDb.Exceptions;
using PluginPolls.PollsDb.Services;

namespace PluginPolls.PollsDb.Controller;

[ApiController]
[Route("[controller]")]
public class QuotesController : ControllerBase
{
    private readonly QuotesService _dbService;

    public QuotesController(QuotesService service) => _dbService = service;

    [HttpGet]
    public async Task<ActionResult<Quote>> GetRandomQuote()
    {
        try
        {
            return await _dbService.GetRandomQuoteAsync();
        }
        catch (QuoteException e)
        {
            return BadRequest(e.Message);
        }
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Quote>> AddQuoteToDb([FromBody] QuoteDto quoteDto)
    {
        try
        {
            return await _dbService.AddQuoteAsync(quoteDto, User.GetUUID(), User.GetUsername());
        }
        catch (QuoteException e)
        {
            return BadRequest(e.Message);
        }
    }
}
