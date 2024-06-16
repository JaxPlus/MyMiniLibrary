using Microsoft.EntityFrameworkCore;
using MyMiniLibrary.Data;
using MyMiniLibrary.Interfaces;
using MyMiniLibrary.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IPublishingHouseRepository, PublishingHouseRepository>();
builder.Services.AddScoped<ISeriesRepository, SeriesRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (context, next) =>
{
    context.Response.Headers.AccessControlAllowOrigin = "http://localhost:5173";
    context.Response.Headers.AccessControlAllowCredentials = "true";
    context.Response.Headers.AccessControlAllowHeaders = "Access-Control-Allow-Headers, Origin, Accept, X-Requested-With, Content-Type, Access-Control-Request-Method, Access-Control-Request-Headers";
    context.Response.Headers.AccessControlAllowMethods = "GET, HEAD, OPTIONS, POST, PUT";
    await next(context);
});

app.UseCors(options => options
        .WithOrigins("http://localhost:5174")
        .AllowAnyMethod());

app.UseHttpsRedirection();

app.MapControllers();

app.Run();