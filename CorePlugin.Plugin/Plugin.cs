using Core.Plugin.Interface;
using CorePlugin.QuoteDb;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PluginPolls.PollsDb.Services;

namespace PluginPolls.PollsDb;

public class Plugin : ICorePlugin
{
    public void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<QuotesContext>(db =>
        {
            var connectionString = builder.Configuration.GetConnectionString("QuotesDbConnection");
            db.UseSqlite(connectionString);
        });
        builder.Services.AddScoped<QuotesService>();
        builder.Services.AddHostedService<DatabaseBackgroundService>();
        builder.Services.AddControllers();
    }

    public void Configure(WebApplication app)
    {
        app.MapControllers();
    }
}
