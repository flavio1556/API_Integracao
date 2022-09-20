using API_Integracao.Data.Context;
using API_Integracao.Mappings;
using API_Integracao.Repository;
using API_Integracao.Repository.Person;
using API_Integracao.Service;
using AutoMapper;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new EntityToDtoProfile());
    ;
});
IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddTransient<IPerson, PersonImplementations>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(RepositoryImplementations<>));
builder.Services.AddScoped(typeof(IPersonRepository), typeof(PersonRepositoryImplementations));
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Api Integração",
        Version = "v1"
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Integração");
    options.RoutePrefix = string.Empty;
}
    );
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
