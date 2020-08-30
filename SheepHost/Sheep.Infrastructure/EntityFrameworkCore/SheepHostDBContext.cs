using Microsoft.EntityFrameworkCore;
using System;

namespace Sheep.Infrastructure.EntityFrameworkCore
{
    public class SheepHostDBContext : DbContext
    {
        public SheepHostDBContext(DbContextOptions<SheepHostDBContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().ToTable("Blogs");
        }

        public DbSet<Blog> Blogs { get; set; }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
    }

    public static class DbInitializer
    {
        public static void Initialize(SheepHostDBContext context)
        {
            context.Database.EnsureCreated();           
        }
    }
}
