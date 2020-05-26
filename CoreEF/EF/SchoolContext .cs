using CoreEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CoreEF.EF
{
    public class SchoolContext:DbContext
    {
        public static IConfiguration Configuration { get; set; }

        public DbSet<Student> Student { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Course2> Course2 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            //get the connstring
            optionsBuilder.UseSqlServer(Configuration["DB"]);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Course>()
           .HasKey(c => c.Id);

            modelBuilder.Entity<Student>()
           .Property<int>("CourseID");

            //Course2ID does not build FK ,so we need build relation
            modelBuilder.Entity<Student>()
                .HasOne(p => p.Course2)
                .WithMany(b => b.Students)
                .HasForeignKey(p => p.Course2ID);

        }
    }
}
