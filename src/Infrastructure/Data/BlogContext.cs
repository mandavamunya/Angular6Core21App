using Application.Core.Entities;
using Microsoft.EntityFrameworkCore;

public class BlogContext : DbContext {
    public BlogContext(DbContextOptions<BlogContext> options) : base(options)
    {
    }

    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<BlogCategory> BlogCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Blog>()
            .HasIndex(o => new { o.PostType })
            .IsUnique();

        builder.Entity<BlogCategory>()
            .HasIndex(o => new { o.Type })
            .IsUnique();
    }
}