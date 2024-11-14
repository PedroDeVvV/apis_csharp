using Microsoft.EntityFrameworkCore;
using MyTasks.Models;

namespace MyTasks.Data
{
    public class TaskSystemDBContext : DbContext
    {
        public TaskSystemDBContext(DbContextOptions<TaskSystemDBContext> option) : base(option) 
        {
        }

        public DbSet<UserModel>Users { get; set; }
        public DbSet<TaskModel>Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
