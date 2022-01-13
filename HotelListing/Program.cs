using Serilog;
using Serilog.Events;


// logger ...
Log.Logger = new LoggerConfiguration()
    .WriteTo.File(path: "D:\\Tech\\NET_CORE\\hotel-listing-webapi\\HotelListing\\HotelListing\\logs\\log-.txt",
    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
    rollingInterval: RollingInterval.Day,
    restrictedToMinimumLevel: LogEventLevel.Information)
    .CreateLogger();

try {
    Log.Information("Starting up");
    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseSerilog();
    
    // services ...
    builder.Services.AddControllers();
    builder.Services.AddCors(x => {
        x.AddPolicy("AllowAll", x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
    });

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();
    if (app.Environment.IsDevelopment()) {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseCors("AllowAll");
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
catch (Exception e) { 
    Log.Fatal(e, "Unhandled exception");
}
finally {
    Log.CloseAndFlush();
}