using Core.Plugin.Interface;
using CorePlugin.Plugin.Services;
using CorePlugin.QuoteDb;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CorePlugin.Plugin;

public class Plugin : ICorePlugin
{
    public void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<QuotesContext>(db =>
        {
            var connectionString = builder.Configuration.GetConnectionString("QuotesDbConnection");
            db.UseSqlite(connectionString);
        });
        builder.Services.AddSingleton<QuoteOfTodayService>();
        builder.Services.AddScoped<QuotesService>();
        builder.Services.AddHostedService<DatabaseBackgroundService>();
        builder.Services.AddControllers();
    }

    public void Configure(WebApplication app) => app.MapControllers();
}
