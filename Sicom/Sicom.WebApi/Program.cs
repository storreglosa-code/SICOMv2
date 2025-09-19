using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Sicom.Dominio.Context;
using Sicom.WebApi.App_Config;
using AutoMapper.Configuration.Conventions;

//ESTE ARCHIVO FUE ADAPTADO POR ChatGPT ya que en .NET 2.1 la configuracion se repartia entre Program.cs y Startup.cs
var builder = WebApplication.CreateBuilder(args);


// --- Servicios (antes en ConfigureServices) ---
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });


// DbContext con SQL y Lazy Loading
builder.Services.AddDbContext<AppDbContext>(options =>
options
.UseLazyLoadingProxies()
.UseSqlServer(
builder.Configuration.GetConnectionString("DbConnection"),
sql => sql.MigrationsAssembly(typeof(Program).Assembly.FullName)
)
);


// CORS
builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", b =>
{
    b.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));


// AutoMapper
builder.Services.AddAutoMapper(cfg => { }, typeof(Program).Assembly);

// Servicios propios
builder.Services.BindServices();

// Swagger (ya estaba en tu Program.cs original)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


// --- Middleware (antes en Configure) ---
app.InitializeSpfDatabase(app.Environment);


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHsts();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();