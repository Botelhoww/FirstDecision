using FirstDecision.Business.Services;
using FirstDecision.Business.Services.Interfaces;
using FirstDecision.Business.Validators;
using FirstDecision.DataLayer.Context;
using FirstDecision.DataLayer.Repositories;
using FirstDecision.DataLayer.Repositories.Interfaces;
using FirstDecision.Model.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<FirstDecisionContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
builder.Services.AddScoped<IPessoaService, PessoaService>();
builder.Services.AddScoped<IValidator<Pessoa>, PessoaValidator>();
builder.Services.AddScoped<IValidator<Pessoa>, EmailValidator>();
builder.Services.AddScoped<CpfCnpjValidator>();

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
