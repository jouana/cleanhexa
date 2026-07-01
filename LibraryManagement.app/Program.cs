using LibraryManagement.app.Application.Commands;
using LibraryManagement.app.Application.Handlers;
using LibraryManagement.app.Application.Presenters;
using LibraryManagement.app.Application.Queries;
using LibraryManagement.app.Domain.Repositories;
using LibraryManagement.app.Infrastructure.Persistence;
using LibraryManagement.app.Infrastructure.Persistence.Sql;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddDbContext<LibraryDbContext>(opt => opt.UseInMemoryDatabase("LibraryDb"));
builder.Services.AddScoped<IBookDao, BookDAOSQL>();
builder.Services.AddScoped<IAuthorDao, AuthorDAOSQL>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddSingleton<ILibraryRepository, InMemoryLibraryRepository>();
builder.Services.AddScoped<ICommandHandler<RegisterBookCommand, IRegisterBookPresenter>, RegisterBookCommandHandler>();
builder.Services.AddScoped<ICommandHandler<PutBookAwayCommand, IPutBookAwayPresenter>, PutBookAwayHandler>();
builder.Services.AddScoped<IQueryHandler<GetBookByISBNQuery, BookReadModel?>, GetBookByISBNQueryHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.MapOpenApi();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
