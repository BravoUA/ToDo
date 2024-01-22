using Microsoft.EntityFrameworkCore;
using ToDo.Models;

namespace ToDo
{
    public class dbConnect:DbContext
    {
        public DbContext DbContext { get; set; }

        public DbSet<ToDoTask> ToDoTask { get; set; }

        public dbConnect(DbContextOptions<dbConnect> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
