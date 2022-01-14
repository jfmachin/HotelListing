using HotelListing.Data;
using HotelListing.Models.Mapper;
using Microsoft.EntityFrameworkCore;
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
    var connectionString = builder.Configuration.GetConnectionString("sqlConnection");
    builder.Host.UseSerilog();

    // services ...
    builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));
    builder.Services.AddCors(x => {
        x.AddPolicy("AllowAll", x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
    });
    builder.Services.AddAutoMapper(typeof(MapperProfile));
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddControllers();

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