using Microsoft.EntityFrameworkCore;

namespace WorldTravelBlog.Models
{
    public class WorldTravelBlogContext : DbContext
    {
        public WorldTravelBlogContext()
        {
        }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Experience> Experiences { get; set; }

        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=8889;database=WorldTravelBlog;uid=root;pwd=root;");
        }

        public WorldTravelBlogContext(DbContextOptions<WorldTravelBlogContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}