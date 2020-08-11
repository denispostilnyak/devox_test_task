using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DevoxTestTask.DAL
{
    public class DevoxTestTaskDbContextFactory: IDesignTimeDbContextFactory<DevoxTestTaskDbContext>
    {
        public DevoxTestTaskDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<DevoxTestTaskDbContext>();
            optionBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS01;Database=DevoxTestTaskDatabases;Trusted_Connection=true");

            return new DevoxTestTaskDbContext(optionBuilder.Options);
        }
    }
}
