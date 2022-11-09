using ApplicationsServices;
using Persistence;
using Veterinary.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddApiVersioningExtension();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseErrorHandlingMiddlerware();

app.MapControllers();

app.Run();

//using FluentValidation;
//using FluentValidation.AspNetCore;
//using Veterinary.Infrastructure.Data;
//using Microsoft.EntityFrameworkCore;
//using System.Reflection;
//using Veterinary.Infrastructure.Services;
//using Veterinary.Infrastructure.Repositories;
//using Veterinary.DomainClass.Entity;
//using ApplicationsServices;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddApplicationLayer();
//builder.Services.AddPersistenceInfrastructure();


//Esto es del inicio, ahora cambio un poco.
////Inyeccion de dependecias al contexto:
//builder.Services.AddDbContext<VeterinaryContex>(options =>
// options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext") ?? throw new InvalidOperationException("Connection string 'DbContext' not found.")));

////Inyeccion de dependencias de los repositorios a los controladores. Cada que pidan crear un objeto en base a IClientRepository
////Se creará un objeto ClientRepository (porque es imposible crear un objeto en base a una interfaz)
//builder.Services.AddScoped<IClientRepository, ClientRepository>();
//builder.Services.AddScoped<IPetRepository, PetRepository>();
//builder.Services.AddScoped<IVisitRepository, VisitRepository>();
//builder.Services.AddScoped<IPetTypeRepository, PetTypeRepository>();
//builder.Services.AddScoped<IProcedureRepository, ProcedureRepository>();
//builder.Services.AddScoped<ISpecialtyRepository, SpecialtyRepository>();
//builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddScoped<IUserRolRepository, UserRolRepository>();
//builder.Services.AddScoped<IVisitDetailRepository, VisitDetailRepository>();
//builder.Services.AddControllers();

////Inyección de dependencias de FluentValidator:
//builder.Services.AddFluentValidationClientsideAdapters();
//builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
////builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
