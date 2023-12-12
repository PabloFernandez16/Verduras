using Microsoft.EntityFrameworkCore;
using WS_VentaVerduras.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//* * * * * * * * * * ** *  * * * * **  ** * * * * * * * 
builder.Services.AddDbContext<VentaDCContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaConexion"));

    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//********
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
