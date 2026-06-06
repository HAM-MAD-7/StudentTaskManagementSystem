using Microsoft.EntityFrameworkCore;
using StudentTaskManagementSystem.Models;

namespace StudentTaskManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<StudentTaskModel> StudentTasks { get; set; }
        public DbSet<UserModel> UserCredentials { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
