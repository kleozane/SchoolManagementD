using Microsoft.EntityFrameworkCore;

namespace SchoolManagementD.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {    
        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
