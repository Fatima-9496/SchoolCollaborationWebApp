using Microsoft.EntityFrameworkCore;
using SchoolApp.Data;
using SchoolApp.Data.Migrations;
using System;

namespace SchoolApp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Courses.Any())
                {
                    return;   // DB has been seeded
                }

                context.Courses.AddRange(
                    new Course
                    {
                        CourseName = "When Harry Met Sally",
                        CourseDescription = "When Harry Met Sally"

                    },

                    new Course
                    {
                        CourseName = "When Harry Met Sally",
                        CourseDescription = "When Harry Met Sally"

                    }

                    
                );
                context.SaveChanges();
            }
        }
    }
}
