namespace PluginPolls.PollsDb.Exceptions;

public class NoQuotePresentException : QuoteException
{
    public NoQuotePresentException(string? message) : base(message) { }
}
