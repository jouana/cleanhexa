using LibraryManagement.app.Application.UseCases;
using LibraryManagement.app.Domain.Repositories;
using LibraryManagement.app.Infrastructure.Persistence;
using LibraryManagement.app.Infrastructure.Persistence.Sql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddScoped<IBookDao, BookDAOSQL>();
builder.Services.AddScoped<IAuthorDao, AuthorDAOSQL>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<RegisterBookUseCase>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.MapOpenApi();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
