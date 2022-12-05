using System.ComponentModel.DataAnnotations;

namespace PluginPolls.PollsDb.Dtos;

public class QuoteDto
{
    [Required] public string QuoteText { get; set; } = null!;
}
