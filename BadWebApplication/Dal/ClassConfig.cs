using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BadWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BadWebApplication.Dal
{
    // Fluent API
    public class CourseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(k => k.CourseId);
            builder.Property(p => p.CourseId).ValueGeneratedOnAdd();
            builder.Property(p => p.Credits).IsRequired();

            // Relationship between Course and Department
            builder.HasOne(d => d.Department)
                .WithMany(c => c.Courses)
                .HasForeignKey(f => f.DepartmentId);
        }
    }

    public class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(k => k.DepartmentId);
            builder.Property(p => p.DepartmentId).ValueGeneratedOnAdd();
            builder.Property(p => p.DepartmentName).IsRequired().HasColumnType("Nvarchar(50)");
            builder.Property(p => p.Budget).HasColumnType("decimal(18, 2)").IsRequired();

            /*builder.HasMany(m => m.Courses)
                .WithOne(o => o.Department)
                .HasForeignKey(f => f.DepartmentId);*/
        }
    }
}
