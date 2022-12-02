using Microsoft.EntityFrameworkCore;
using Task4_ReadingList.DataAccess.Context;
using Task4_ReadingList.DataAccess.Repositories.BookRepository;
using Task4_ReadingList.Service.Services.BookService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ReadingListDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connectionString")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//Repositories
builder.Services.AddScoped<IBookRepository, BookRepository>();

//Services
builder.Services.AddScoped<IBookService, BookService>();

//Validators

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseDefaultFiles();
    app.UseStaticFiles();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
