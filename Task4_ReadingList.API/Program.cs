using Microsoft.EntityFrameworkCore;
using Task4_ReadingList.DataAccess.Context;
using Task4_ReadingList.DataAccess.Repositories.AuthorRepository;
using Task4_ReadingList.DataAccess.Repositories.BookRepository;
using Task4_ReadingList.Service.Services.AuthorService;
using Task4_ReadingList.Service.Services.BookService;

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


//Validators

var app = builder.Build();

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
