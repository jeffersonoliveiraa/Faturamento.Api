using Faturamento.Domain.Commands.v1.Faturamento.Create;
using Faturamento.Domain.Contracts.v1.Repository;
using Faturamento.Infra.Data.Context.v1;
using Faturamento.Infra.Data.Queries.Queries.v1.GetAll;
using Faturamento.Infra.Data.Repositories.v1;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddMediatR(typeof(CreateFaturamentosCommand));
builder.Services.AddMediatR(typeof(GetAllFaturamentosQuery));
var cs = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DbContextClass>(opt => opt.UseSqlServer(cs));
builder.Services.AddScoped<IFaturamentoRepository, FaturamentosRepository>();

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
