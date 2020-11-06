using BadWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BadWebApplication.Dal
{
    public class BadContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }

        public BadContext(DbContextOptions<BadContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CourseConfig());
        }
    }
}
