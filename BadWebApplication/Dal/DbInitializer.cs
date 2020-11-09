using BadWebApplication.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BadWebApplication.Dal
{
    public static class DbInitializer
    {
        public static void Seed(IApplicationBuilder builder)
        {
            using (IServiceScope serviceScope = builder.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                BadContext context = serviceScope.ServiceProvider.GetService<BadContext>();

                if (!context.Departments.Any())
                {
                    context.Departments.AddRange(Departments.Values);
                }

                if (!context.Courses.Any())
                {
                    var courseList = new List<Course>
                    {
                        new Course() {CourseName = "C#", Department = Departments["Programming"], Credits = 3},
                        new Course() {CourseName = "HTML", Department = Departments["Design"], Credits = 2},
                        new Course() {CourseName = "CCNA", Department = Departments["Network"], Credits = 2}
                    };
                    context.Courses.AddRange(courseList);
                }

                context.SaveChanges();
            }
        }

        private static Dictionary<string, Department> departments;

        public static Dictionary<string, Department> Departments
        {
            get
            {
                if (departments != null)
                    return departments;

                var deptList = new[]
                {
                    new Department() { DepartmentName = "Programming"},
                    new Department() { DepartmentName = "Design"},
                    new Department() { DepartmentName = "Network"}
                };

                departments = new Dictionary<string, Department>();

                foreach (var department in deptList)
                {
                    departments.Add(department.DepartmentName,  department);
                }

                return Departments;
            }
        }
    }
}
