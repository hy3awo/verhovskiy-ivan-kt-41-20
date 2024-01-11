using NLog;
using NLog.Web;
using VerhovskiyIvanKT_41_20.Database;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var logger = LogManager.Setup()
.LoadConfigurationFromAppSettings().GetCurrentClassLogger();

try
{   // Add services to the container.
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<GroupsDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch(Exception ex)
{
    logger.Error(ex, "Stopped program because of exception");
}
finally
{
    LogManager.Shutdown();
}