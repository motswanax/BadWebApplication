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
            using (var serviceScope = builder.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope()) ;
            {
                var context = serviceScope.ServiceProvider.GetService<BadContext>();

                if (context.Courses.Any())
                {
                    var courseList = new List<Course>
                    {
                        new Course() {CourseName = "C#", Department = Departments["Programming"], CourseId = 8},
                        new Course() {CourseName = "C#", Department = Departments["Design"], CourseId = 8}
                    }
                }
            }
        }

        private static Dictionary<string, Department> departments;

        public static Dictionary<string, Department> Departments
        {
            get
            {
                if (Departments != null)
                    return Departments;

                var deptList = new[]
                {
                    new Department() { DepartmentName = "Programming"},
                    new Department() { DepartmentName = "Design"},
                    new Department() { DepartmentName = "Network"}
                };

                Departments = new Dictionary<string, Department>();

                foreach (var department in deptList)
                {
                    Departments.Add(department.DepartmentName,  department);
                }

                return Departments;
            }
            
        }

    }
}
