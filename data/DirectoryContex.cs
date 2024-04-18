using Microsoft.EntityFrameworkCore;

namespace Contacts.Api;

public class DirectoryContex(DbContextOptions<DirectoryContex> options) : DbContext(options)
{
    public DbSet<Person> people { get; set; }
    public DbSet<phoneNumber> numbers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<phoneNumber>().HasData(
            new { Id = 1, phoneNumberName = "5537622553" },
            new { Id = 2, phoneNumberName = "5537622525" },
            new { Id = 3, phoneNumberName = "5537522553" },
            new { Id = 4, phoneNumberName = "5587622553" }
        );
    }
}


