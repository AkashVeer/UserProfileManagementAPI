using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserProfileManagementAPI.Entities;

namespace UserProfileManagementAPI.Database
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public ApplicationDbContext(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("ConnectionString"));
        }
        public DbSet<User> Users { get; }
    }
}
