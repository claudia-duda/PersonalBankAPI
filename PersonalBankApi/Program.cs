using Microsoft.EntityFrameworkCore;
using PersonalBankModels.Profiles;
using PersonalBankRepositories.Repositories;
using PersonalBankServices.Interfaces;
using PersonalBankServices.Repositories;
using PersonalBankRepositories;
using PersonalBankRepositories.Interfaces;

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
builder.Services.AddTransient<IWithdrawRepository, WithdrawRepository>();
builder.Services.AddTransient<IAccountRepository, AccountRepository>();

builder.Services.AddScoped<IDepositService, DepositService>();
builder.Services.AddScoped<ITransferService, TransferService>();
builder.Services.AddScoped<IWithdrawService, WithdrawService>();
builder.Services.AddScoped<IAccountService, AccountService>();

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
