using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WorldTravelBlog.Models;

namespace WorldTravelBlog.Migrations
{
    [DbContext(typeof(WorldTravelBlogContext))]
    partial class WorldTravelBlogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("WorldTravelBlog.Models.Experience", b =>
                {
                    b.Property<int>("ExperienceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int?>("LocationId");

                    b.HasKey("ExperienceId");

                    b.HasIndex("LocationId");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("WorldTravelBlog.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("WorldTravelBlog.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ExperienceId");

                    b.Property<int?>("LocationId");

                    b.Property<string>("Name");

                    b.HasKey("PersonId");

                    b.HasIndex("ExperienceId");

                    b.HasIndex("LocationId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("WorldTravelBlog.Models.Experience", b =>
                {
                    b.HasOne("WorldTravelBlog.Models.Location", "Location")
                        .WithMany("Experiences")
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("WorldTravelBlog.Models.Person", b =>
                {
                    b.HasOne("WorldTravelBlog.Models.Experience", "Experience")
                        .WithMany()
                        .HasForeignKey("ExperienceId");

                    b.HasOne("WorldTravelBlog.Models.Location", "Location")
                        .WithMany("People")
                        .HasForeignKey("LocationId");
                });
        }
    }
}
