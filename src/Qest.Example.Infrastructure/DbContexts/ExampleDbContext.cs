using Microsoft.EntityFrameworkCore;
using Qest.Example.Entities;

namespace Qest.Example.DbContexts
{
  internal sealed class ExampleDbContext: DbContext
  {
    public ExampleDbContext(DbContextOptions<ExampleDbContext> options)
      : base(options) { }

    public DbSet<UserEntity> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      var users = modelBuilder.Entity<UserEntity>()
        .ToTable("users");

      users.HasIndex(e => e.Email).IsUnique();
      users.HasIndex(e => e.Role);
      users.HasIndex(e => new
      {
        e.LastName,
        e.FirstName
      });
    }
  }
}
