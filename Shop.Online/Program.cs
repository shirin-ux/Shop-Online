using Asp.Versioning;
using Microsoft.EntityFrameworkCore;
using Shop.Application.IServices;
using Shop.Domain.Interface;
using Shop.Domain.IRepository;
using Shop.Infrastructure;
using Shop.Infrastructure.BackgroundService;
using Shop.Infrastructure.ExternalServices;
using Shop.Infrastructure.Persistence;
using Shop.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EFCoreDbContext>(Options =>
Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

builder.Services.AddApiVersioning(x =>
{
    x.DefaultApiVersion = new ApiVersion(1, 0);
    x.ReportApiVersions = true;
    x.AssumeDefaultVersionWhenUnspecified = true;
    x.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),
        new HeaderApiVersionReader("X-Api-Version"));
}).AddApiExplorer()
.AddMvc()
.AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});
builder.Services.Configure<KafkaSettings>(builder.Configuration.GetSection("Kafka"));
builder.Services.AddScoped<IApplicationDbContext, EFCoreDbContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IPaymentStrategy, MellatPaymentStrategy>();
builder.Services.AddScoped<IPaymentStrategy, SamanPaymentStrategy>();
builder.Services.AddScoped<IPaymentStrategy, ZarinpalPaymentStrategy>();
builder.Services.AddScoped<IPaymentStrategyFactory, PaymentStrategyFactory>();
builder.Services.AddSingleton<KafkaProducerService>();
builder.Services.AddHostedService<OutboxProcessorService>();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
