using Business.Interfaces;
using Business.Services;
using Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inject db
builder.Services.Configure<DbSettings>(builder.Configuration.GetSection("MongoDB"));
//Inject multiple classes to one service
builder.Services.AddScoped(typeof(IService<PersonService, string>), typeof(PersonService));
builder.Services.AddScoped(typeof(IService<CompanyService, string>), typeof(CompanyService));
builder.Services.AddScoped(typeof(IService<AnimalService, string>), typeof(AnimalService));
builder.Services.AddScoped(typeof(IService<CountryService, string>), typeof(CountryService));

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
