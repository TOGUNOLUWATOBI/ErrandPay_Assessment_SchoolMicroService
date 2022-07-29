using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Migrations
{
    public class AppDbContext1 : IdentityDbContext<User>
    {
        public DbSet<User> User { get; set; }
        public DbSet<Course> Course { get; set; }

        public AppDbContext1()
        {
        }

        public AppDbContext1(DbContextOptions<AppDbContext1> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
