﻿using Core.Utilities;
using Microsoft.EntityFrameworkCore;

namespace $safeprojectname$
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = ConnectionInfo.Instance.MySQLServerConnectionString;
            optionsBuilder.UseMySQL(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
