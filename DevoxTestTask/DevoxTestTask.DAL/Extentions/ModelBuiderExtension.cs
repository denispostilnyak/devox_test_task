using System;
using System.Collections.Generic;
using System.Text;
using DevoxTestTask.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevoxTestTask.DAL.Extentions
{
    public static class ModelBuiderExtension
    {
        internal static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasData( new Project[]
                {
                    new Project
                    {
                        Id = 1,
                        Name = "First",
                        DateStart = DateTime.Now,
                        DateEnd = DateTime.Parse("20.08.2020")
                    },
                    new Project
                    {
                        Id = 2,
                        Name = "Second",
                        DateStart = DateTime.Now,
                        DateEnd = DateTime.Parse("21.08.2020")
                    },
                    new Project
                    {
                        Id = 3,
                        Name = "Third",
                        DateStart = DateTime.Now,
                        DateEnd = DateTime.Parse("22.08.2020")
                    }
                });

            modelBuilder.Entity<Employee>()
                .HasData(new Employee[]
                {
                    new Employee
                    {
                        Id = 1,
                        Name = "Denis",
                        Sex = "m",
                        Birthday = DateTime.Parse("28.10.2000")
                    },
                    new Employee
                    {
                        Id = 2,
                        Name = "Anton",
                        Sex = "m",
                        Birthday = DateTime.Parse("11.11.2001")
                    }
                });

            modelBuilder.Entity<Role>()
                .HasData(new Role[]
                {
                    new Role
                    {
                        Id = 1,
                        Name = "engineer"
                    },
                    new Role
                    {
                        Id = 2,
                        Name = "analyst"
                    }
                });

            modelBuilder.Entity<ActivityType>()
                .HasData(new ActivityType[]
                {
                    new ActivityType
                    {
                        Id = 1,
                        Name = "regular"
                    },
                    new ActivityType
                    {
                        Id = 2,
                        Name = "overtime"
                    }
                });

            modelBuilder.Entity<Activity>()
                .HasData(new Activity[]
                {
                    new Activity
                    {
                        Id = 1,
                        Name = "FirstActivity",
                        ProjectId = 1,
                        EmployeeId = 1,
                        RoleId = 1,
                        ActivityTypeId = 1,
                        Date = DateTime.Parse("10.08.2020"),
                        Duration = 3
                    },
                    new Activity
                    {
                        Id = 2,
                        Name = "SecondActivity",
                        ProjectId = 2,
                        EmployeeId = 2,
                        RoleId = 2,
                        ActivityTypeId = 2,
                        Date = DateTime.Parse("09.08.2020"),
                        Duration = 5
                    },
                    new Activity
                    {
                        Id = 3,
                        Name = "ThirdActivity",
                        ProjectId = 2,
                        EmployeeId = 1,
                        RoleId = 2,
                        ActivityTypeId = 1,
                        Date = DateTime.Parse("10.08.2020"),
                        Duration = 2
                    }
                });
        }
    }
}
