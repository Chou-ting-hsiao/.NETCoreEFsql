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
            modelBuilder.Entity<Course>(entity => {
                entity.HasKey(x => x.Id);
            });

            modelBuilder.Entity<Course2>(entity => {
                entity.HasKey(x => x.Id);
            });

            modelBuilder.Entity<Student>(entity => {
                entity.HasKey(x => x.Id);

                entity.HasOne(p => p.Course)
                      .WithMany(b => b.Students)
                      .HasForeignKey(p => p.CID);

                entity.HasOne(p => p.Course2)
                      .WithMany(b => b.Students)
                      .HasForeignKey(p => p.C2ID);
            });
            
        }
    }
}
