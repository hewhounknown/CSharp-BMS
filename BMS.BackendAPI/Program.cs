using BMS.BackendAPI.Features.Accounts;
using BMS.BackendAPI.Features.Transations;
using BMS.Shared.Services;
using BMS.WebAPI.Features.Customers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("DBConnection")!;

builder.Services.AddScoped(n => new DapperService(connectionString))
    .AddScoped<AccountRepository>()
    .AddScoped<AccountService>()
    .AddScoped<TransationService>()
    .AddScoped<TransationRepository>()
    .AddScoped<CustomerRepository>()
    .AddScoped<CustomerService>();

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
