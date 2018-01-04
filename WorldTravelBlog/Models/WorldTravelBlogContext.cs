using System;
using Microsoft.EntityFrameworkCore;

namespace WorldTravelBlog.Models
{
    public class WorldTravelBlogContext : DbContext
    {
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }
        public virtual DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseMySql(@"Server=localhost;Port=8889;database=worldtravelblog;uid=root;pwd=root;");
    }
}
