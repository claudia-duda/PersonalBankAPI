using Microsoft.EntityFrameworkCore;
using PersonalBankModels.Profiles;
using PersonalBankRepositories.Repositories;
using PersonalBankServices.Interfaces;
using PersonalBankServices.Repositories;
using Repositories;
using Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlServer<AppDbContext>(
    builder.Configuration.GetConnectionString("DataBase")
);

builder.Services.AddTransient<IDepositRepository, DepositRepository>();
builder.Services.AddTransient<ITransferRepository, TransferRepository>();

builder.Services.AddScoped<IDepositService, DepositService>();
builder.Services.AddScoped<ITransferService, TransferService>();

builder.Services.AddAutoMapper(typeof(DepositProfile));
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
