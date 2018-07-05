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
        public DbSet<Class> Class { get; set; }

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

            // modelBuilder.Entity<Class>()
            //.HasKey(c => c.Id);

            // modelBuilder.Entity<Student>()
            //.Property<int>("ClassID");

            //class2 does not build FK ,so we need build relation
            //modelBuilder.Entity<Student>()
            //    .HasOne(p => p.Class2)
            //    .WithMany(b => b.Students)
            //    .HasForeignKey(p => p.Class2ID);

        }
    }
}
