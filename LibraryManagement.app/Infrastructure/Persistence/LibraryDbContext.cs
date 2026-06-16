using LibraryManagement.app.Infrastructure.Persistence.Sql.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.app.Infrastructure.Persistence;

public class LibraryDbContext(DbContextOptions<LibraryDbContext> options) : DbContext(options)
{
    public DbSet<BookEntity> Books => Set<BookEntity>();
}
