using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.DBContext
{

    public class TaskManagementDbContext : DbContext
        {
            public TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> options) : base(options)
            {

            }
        public DbSet<TaskEntity>   taskEntities { get; set; }

    }
}
