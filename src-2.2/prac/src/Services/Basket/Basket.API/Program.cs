using Common.Logging;
using Serilog;

//Log.Logger = new LoggerConfiguration()
//    .WriteTo.Console()
//    .CreateBootstrapLogger();

//Log.Information(messageTemplate:"Starting Product API up");

var builder = WebApplication.CreateBuilder(args);

// Sau khi add reference
builder.Host.UseSerilog(Serilogger.Configure);

Log.Information(messageTemplate: "Starting Basket API up");


try
{
    //var builder = WebApplication.CreateBuilder(args);

    //builder.Host.UseSerilog(configureLogger: (ctx, lc) => lc
    //    .WriteTo.Console(
    //        outputTemplate:
    //        "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{NewLine}{Exception}{NewLine}"
    //    ).Enrich.FromLogContext()
    //    .ReadFrom.Configuration(ctx.Configuration));

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, messageTemplate: "Unhadled exception");
}
finally
{
    Log.Information(messageTemplate: "Shut down Basket API complete");
    Log.CloseAndFlush();
}