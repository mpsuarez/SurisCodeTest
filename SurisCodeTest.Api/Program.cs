using Microsoft.EntityFrameworkCore;
using SurisCodeTest.Persistence;
using SurisCodeTest.Persistence.Entities;
using SurisCodeTest.Repositories;
using SurisCodeTest.Repositories.Generic;
using SurisCodeTest.Services;
using SurisCodeTest.Services.Validators.ReserveValidators;
using System.Configuration;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<SurisCodeTestDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("SurisCodeTestConnectionString")));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IReserveValidation, DateValidation>();
builder.Services.AddScoped<IReserveValidation, ServiceWorkingTimeValidation>();
builder.Services.AddScoped<IReserveValidation, SameReserveValidation>();
builder.Services.AddScoped<ReserveValidation>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<ReserveRepository>();
builder.Services.AddScoped<ServiceRepository>();
builder.Services.AddScoped<ServiceWorkingTimeRepository>();

builder.Services.AddScoped<ReserveService>();
builder.Services.AddScoped<ServiceService>();
builder.Services.AddScoped<ServiceWorkingTimeService>();

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

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
