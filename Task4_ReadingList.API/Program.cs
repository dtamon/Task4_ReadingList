using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Task4_ReadingList.DataAccess.Context;
using Task4_ReadingList.DataAccess.Repositories.AuthorRepository;
using Task4_ReadingList.DataAccess.Repositories.BookRepository;
using Task4_ReadingList.DataAccess.Seeder;
using Task4_ReadingList.Service.Services.AuthorService;
using Task4_ReadingList.Service.Services.BookService;
using Task4_ReadingList.Service.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ReadingListDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connection")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//enable CORS
builder.Services.AddCors(c => {
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

//Repositories
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();

//Services
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();

//Seeder
builder.Services.AddScoped<ReadingListSeeder>();

//FluentValidation Validators
builder.Services.AddFluentValidationAutoValidation(config =>
{
    config.DisableDataAnnotationsValidation = true;
})
    .AddValidatorsFromAssemblyContaining<AuthorValidator>();

var app = builder.Build();

//Seed data
app.Services.CreateScope().ServiceProvider.GetRequiredService<ReadingListSeeder>().Seed();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
