using FluentValidation;
using Verra.Employees.Api.DataMappings;
using Verra.Employees.Api.Models;
using Verra.Employees.Domain.Aggregates.EmployeeAggregate;
using Verra.Employees.Domain.SeedWork;
using Verra.Employees.Infrastructure.DataMappings;
using Verra.Employees.Infrastructure.EntityFramework;
using Verra.Employees.Infrastructure.Services;
using Db = Verra.Employees.Infrastructure.EntityFramework.Tables;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IEmployeeService, EmployeeEfService>();
builder.Services.AddScoped<IUnitOfWork<EmployeesEfDbContext>, EfUnitOfWork<EmployeesEfDbContext>>();
builder.Services.AddScoped<IEmployeeRepository<EmployeesEfDbContext>, EmployeeEfRepository>();
builder.Services.AddScoped<IValidator<Employee>, EmployeeValidator>();
builder.Services.AddScoped<IRepositoryDataMapper<Employee, Db.Employee>, EmployeesRepositoryDataMapper>();
builder.Services.AddScoped<IRepositoryDataMapper<EmployeePosition, Db.EmployeePosition>, EmployeePositionDataMapper>();
builder.Services.AddScoped<IApiDataMapper<Employee, EmployeeDto>>();
builder.Services.AddScoped<IApiDataMapper<EmployeePosition, EmployeePositionDto>>();

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

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();